using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using PostService.Data;
using PostService.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace PostService
{
    public class EventsListener : BackgroundService
    {
        private readonly IModel _channel;
        private readonly IServiceScopeFactory _scopeFactory;


        public EventsListener(IServiceScopeFactory scopeFactory)
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _scopeFactory = scopeFactory;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var postServiceContext = scope.ServiceProvider.GetRequiredService<PostServiceContext>();

                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"[x] Received {message}");

                    var data = JObject.Parse(message);
                    var type = ea.RoutingKey;
                    if (type == "user.add")
                    {
                        if (postServiceContext.User.Any(a => a.ID == data["id"].Value<int>()))
                        {
                            ColorConsole.WriteLine("Ignoring old/duplicate entity");
                        } else
                        {
                            using var transaction = postServiceContext.Database.BeginTransaction();
                            postServiceContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [PostDb].[dbo].[User] ON;");
                            postServiceContext.User.Add(new User()
                            {
                                ID = data["id"].Value<int>(),
                                Name = data["name"].Value<string>(),
                                Version = data["version"].Value<int>()
                            });
                            postServiceContext.SaveChanges();
                            transaction.Commit();
                        }
                    }
                    else if (type == "user.update")
                    {
                        try
                        {
                            int newVersion = data["version"].Value<int>();
                            var user = postServiceContext.User.First(a => a.ID == data["id"].Value<int>());
                            ColorConsole.WriteLine($"user.Version: {user.Version}, newVersion: {newVersion}");
                            if (user.Version >= newVersion)
                            {
                                ColorConsole.WriteLine("Ignoring old/duplicate entity");
                            }
                            else
                            {
                                user.Name = data["newname"].Value<string>();
                                user.Version = newVersion;
                                postServiceContext.SaveChanges();
                            }
                        }
                        catch (Exception e)
                        {
                            ColorConsole.WriteLine(e.Message, ConsoleColor.Red);
                        }
                        
                    }
                }
                _channel.BasicAck(ea.DeliveryTag, false); // ?
            };
            _channel.BasicConsume(queue: "user.postservice",
                                     autoAck: false, // ?
                                     consumer: consumer);

            return Task.CompletedTask;
        }
    }
}

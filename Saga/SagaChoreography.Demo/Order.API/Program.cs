using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Order.API;
using Order.API.Db;
using Plain.RabbitMQ;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrderingContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        )
    );


// Configure rabbitmq
builder.Services.AddSingleton<IConnectionProvider>(
    new ConnectionProvider("amqp://guest:guest@localhost:5672"));
builder.Services.AddSingleton<IPublisher>(p => new Publisher(p.GetService<IConnectionProvider>(),
                "order_exchange", // exchange name
                ExchangeType.Topic));
builder.Services.AddSingleton<ISubscriber>(s => new Subscriber(s.GetService<IConnectionProvider>(),
                "catalog_exchange", // Exchange name
                "catalog_response_queue", //queue name
                "catalog_response_routingkey", // routing key
                ExchangeType.Topic));
builder.Services.AddHostedService<CatalogResponseListener>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
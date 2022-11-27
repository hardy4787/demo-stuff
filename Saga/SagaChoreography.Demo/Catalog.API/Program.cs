using Catalog.API.Db;
using Catalog.API;
using Microsoft.Extensions.Configuration;
using Plain.RabbitMQ;
using RabbitMQ.Client;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CatalogContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddSingleton<IConnectionProvider>(new ConnectionProvider("amqp://guest:guest@localhost:5672"));
builder.Services.AddSingleton<IPublisher>(p => new Publisher(p.GetService<IConnectionProvider>(),
    "catalog_exchange",
    ExchangeType.Topic));

builder.Services.AddSingleton<ISubscriber>(s => new Subscriber(s.GetService<IConnectionProvider>(),
    "order_exchange",
    "order_response_queue",
    "order_created_routingkey",
    ExchangeType.Topic
    ));

builder.Services.AddHostedService<OrderCreatedListener>();
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
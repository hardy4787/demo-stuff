var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("Order", c => c.BaseAddress = new Uri("https://localhost:7241"));
builder.Services.AddHttpClient("Inventory", c => c.BaseAddress = new Uri("https://localhost:7224"));
builder.Services.AddHttpClient("Notifier", c => c.BaseAddress = new Uri("https://localhost:7141"));

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
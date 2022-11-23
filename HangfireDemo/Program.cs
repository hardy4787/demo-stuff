using Hangfire;
using HangfireDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IJobTestService, JobTestService>();
builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(
        builder.Configuration.GetConnectionString("DBConnection"));
});
builder.Services.AddHangfireServer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.UseHangfireDashboard();

app.Run();
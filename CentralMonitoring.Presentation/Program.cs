using CentralMonitoring.Application.Common.Interfaces;
using CentralMonitoring.Application.Services;
using CentralMonitoring.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddHttpClient();
builder.Services.AddScoped<ISiteClient, SiteHttpClient>();
builder.Services.AddScoped<BuildingAggregatorService>();
builder.Services.AddScoped<MonitoringAggregatorService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => new { Message = "Central Monitoring API is running" });

app.Run();

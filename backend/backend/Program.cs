using System.Data;
using backend.DesignPatternSupportClasses;
using backend.Services;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Encoders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DatabaseService>();
builder.Services.AddScoped<DeliveryFacade>();
builder.Services.AddScoped<IDeliveryRequestService, DeliveryRequestService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<ITrackingService, TrackingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

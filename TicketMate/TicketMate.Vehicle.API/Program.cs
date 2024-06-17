using TicketMate.Vehicle.API.Models;
using Microsoft.EntityFrameworkCore;
using TicketMate.Vehicle.Infastructure;
using TicketMate.Vehicle.API.Controllers;
using Microsoft.Extensions.Configuration;
using TicketMate.Vehicle.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add configuration to the application
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VehicleDbContext>();

builder.Services.AddScoped<VehicleDbContext>();


//---- dependency Injection---------
builder.Services.AddScoped<IRegBusSer, RegBusSer>();
builder.Services.AddScoped<ISelSeaStrSer, SelSeaStrSer>();
builder.Services.AddScoped<IScheduledBusSer, ScheduledBusSer>();
builder.Services.AddScoped<ISchBusStandSer, SchBusStandSer>();
builder.Services.AddScoped<IScheduledBusDateSer, ScheduledBusDateSer>();
builder.Services.AddScoped<IBusRouteSer, BusRouteSer>();
builder.Services.AddScoped<IBusRouteStandSer, BusRouteStandSer>();
builder.Services.AddScoped<IuserDataSer, userDataSer>();
builder.Services.AddScoped<IRegisteredLocomotiveSer, RegisteredLocomotiveSer>();
builder.Services.AddScoped<IRegisteredCarriageSer, RegisteredCarriageSer>();
builder.Services.AddScoped<IScheduledTrainSer, ScheduledTrainSer>();
builder.Services.AddScoped<ISelCarriageSeatStructureSer, SelCarriageSeatStructureSer>();
builder.Services.AddScoped<ISelectedTrainStationSer, SelectedTrainStationSer>();
builder.Services.AddScoped<IScheduledTrainDateSer, ScheduledTrainDateSer>();
builder.Services.AddScoped<ITrainRaliwaySer, TrainRaliwaySer>();
builder.Services.AddScoped<ITrainRaliwayStationSer, TrainRaliwayStationSer>();
builder.Services.AddScoped<IScheduledLocomotiveSer, ScheduledLocomotiveSer>();
builder.Services.AddScoped<IScheduledCarriageSer, ScheduledCarriageSer>();


builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//-
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}); 
//


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

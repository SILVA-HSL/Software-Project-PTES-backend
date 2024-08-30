using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TicketMate.Reporting.Api.Controllers;
using TicketMate.Reporting.Application.ReportingService;
using TicketMate.Reporting.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register services

//builder.Services.AddScoped<IAdminReportingService, AdminReportingService>();
//builder.Services.AddScoped<IBusOwnerReportingService, BusOwnerReportingService>();
//builder.Services.AddScoped<ITrainReportingService, TrainReportingService>();
builder.Services.AddScoped<IBusPredictionService, BusPredictionService>();
builder.Services.AddScoped<IBusPredictionDataService, BusPredictionDataService>();
//builder.Services.AddScoped<IPredictionCacheService, PredictionCacheService>();
builder.Services.AddScoped<ITrainPredictionDataService, TrainPredictionDataService>();
builder.Services.AddScoped<ITrainPredictionService, TrainPredictionService>();
// Register your services
builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();




builder.Services.AddHttpClient<IAdminReportingService, AdminReportingService>();

builder.Services.AddScoped<IAdminReportingService>(sp =>
{
    var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient();
    var dbContextOptions = sp.GetRequiredService<DbContextOptions<ReportingDbContext>>();

    return new AdminReportingService(dbContextOptions, httpClient);
});


// Register HttpClient for BusOwnerReportingService
builder.Services.AddHttpClient<IBusOwnerReportingService, BusOwnerReportingService>();
// Explicit scoped registration using factory pattern
builder.Services.AddScoped<IBusOwnerReportingService>(sp =>
{
    var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient();
    var dbContextOptions = sp.GetRequiredService<DbContextOptions<ReportingDbContext>>();
    return new BusOwnerReportingService(dbContextOptions, httpClient);
});


builder.Services.AddHttpClient<ITrainReportingService, TrainReportingService>();
builder.Services.AddScoped<ITrainReportingService>(sp =>
{
    var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient();
    var dbContextOptions = sp.GetRequiredService<DbContextOptions<ReportingDbContext>>();
    return new TrainReportingService(dbContextOptions, httpClient);
});


// Configure logging
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.AddDebug();
    logging.AddEventSourceLogger();
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });
// Configure the database context
builder.Services.AddDbContext<ReportingDbContext>(options =>
{
    options.UseSqlServer("DefaultConnection",
        sqlServerOptions =>
        {
            sqlServerOptions.EnableRetryOnFailure();
        });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.WithOrigins("http://localhost:5173", "http://localhost:5174", "http://localhost:5175", "http://localhost:5176")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});




var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();//app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TicketMate.TravelSearch.Api2"));
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowLocalhost");

app.MapControllers();

app.Run();


using Microsoft.EntityFrameworkCore;
using TicketMate.Reporting.Application.ReportingService;
using TicketMate.Reporting.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register services
builder.Services.AddScoped<IAdminReportingService, AdminReportingService>();
builder.Services.AddScoped<IBusOwnerReportingService, BusOwnerReportingService>();
builder.Services.AddScoped<ITrainReportingService, TrainReportingService>();
builder.Services.AddScoped<IBusPredictionService, BusPredictionService>();
builder.Services.AddScoped<IBusPredictionDataService, BusPredictionDataService>();
builder.Services.AddScoped<IPredictionCacheService, PredictionCacheService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });
// Configure the database context
builder.Services.AddDbContext<ReportingDbContext>(options =>
{
    options.UseSqlServer("Server=tcp:ptesserver.database.windows.net,1433;Initial Catalog=ptescentral;Persist Security Info=False;User ID=AdminPTES;Password=PTES@admin;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
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


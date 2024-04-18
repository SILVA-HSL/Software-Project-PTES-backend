using Microsoft.EntityFrameworkCore;
using TicketMate.Booking.Application.Handlers;
using TicketMate.Booking.Application.Services;
using TicketMate.Booking.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookingService, BookingService>();
// In ConfigureServices method of Startup.cs
builder.Services.AddScoped<TravelSearchHandler>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddDbContext<BookingDbContext>(options =>
{
    //options.UseSqlServer("Server=DILSHAN;Database=BookingDataBase;Trusted_Connection=True;TrustServerCertificate=true;");
    options.UseSqlServer("Server=tcp:ticketmateserver.database.windows.net,1433;Initial Catalog=PTEScentralDb;Persist Security Info=False;User ID=adminPTES;Password=#ticket@MS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
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

/*builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new Ticketmate.TravelSearchApi2.Models.Custom_Converters.DateOnlyConverter());
    });*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TicketMate.TravelSearch.Api2"));
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowLocalhost");

app.MapControllers();

app.Run();
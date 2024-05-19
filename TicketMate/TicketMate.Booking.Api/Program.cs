using Microsoft.EntityFrameworkCore;
using TicketMate.Booking.Application.Handlers;
using TicketMate.Booking.Application.Services;
using TicketMate.Booking.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<TravelSearchHandler>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddDbContext<BookingDbContext>(options =>
{
    options.UseSqlServer("Server=tcp:ptesserver.database.windows.net,1433;Initial Catalog=ptescentral;Persist Security Info=False;User ID=AdminPTES;Password=PTES@admin;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",

   sqlServerOptions =>
   {
       sqlServerOptions.EnableRetryOnFailure();
   }
           );

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
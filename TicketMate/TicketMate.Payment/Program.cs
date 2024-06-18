using Microsoft.EntityFrameworkCore;
using TicketMate.Payment.Data;
//using TicketMate.Admin.Infastructure;
using Stripe;
using TicketMate.Payment.Application.DriverService;
using TicketMate.Payment.Application.BookingServices;
using TicketMate.Payment.Infrastructure;
using TicketMate.Payment.EmailService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//for signalR(update breakdoown)
builder.Services.AddSignalR();

builder.Services.AddScoped<IEmailService, EmailService>();
//builder.Services.AddTransient<IBraintreeService, BraintreeService>();
builder.Services.AddDbContext<userDataDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TicketMateConnection")));
builder.Services.AddScoped<IScheduledBusService, ScheduledBusService>();
builder.Services.AddScoped<IBusBookingService, BusBookingService>();
builder.Services.AddScoped<IScheduledTrainService, ScheduledTrainService>();
builder.Services.AddScoped<ITrainBookingService, TrainBookingService>();
builder.Services.AddScoped<IDriverBreakdownService, DriverBreakdownService>();
builder.Services.AddScoped<IBusLiveUpdateService, BusLiveUpdateService>();
builder.Services.AddScoped<ITrainLiveUpdateService, TrainLiveUpdateService>();
builder.Services.AddScoped<INotoifiBusScheduledIdService, NotoifiBusScheduledIdService>();
builder.Services.AddScoped<INotifiTrainScheduledIdService, NotifiTrainScheduledIdService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.WithOrigins("http://localhost:5173", "http://localhost:5174", "http://localhost:5175", "http://localhost:5176")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials(); // This line is crucial
    });
});

StripeConfiguration.ApiKey = "sk_test_51PKw0t04aP7UQrlkwHDYjmlkU6z88Q7bS3Ng1LFcHQK026XyYCtoEkZUMi1O6of3OkQcIACZbssQB0HLInrrzCX300iJm10YSj";


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();

}



app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowLocalhost");
app.UseAuthorization();

app.MapControllers();
// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapHub<NotificationHub>("/notificationHub");




//app.UseEndpoints(endpoints =>
//{
// endpoints.MapControllerRoute(
//  name: "default",
// pattern: "{controller=Home}/{action=Index}/{id?}");
// endpoints.MapHub<NotificationHub>("/notificationHub");
//});


app.Run();

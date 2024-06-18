using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TicketMate.Payment.Application.DriverService;
using TicketMate.Payment.Infrastructure;
using TicketMate.Payment.Domain.Model;  

namespace TicketMate.Payment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreakdownController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IBusLiveUpdateService _BusLiveUpdateService;
        private readonly ITrainLiveUpdateService _TrainLiveUpdateService;
       // private readonly INotificationRepository _notificationRepository; // Interface for notification repository


        public BreakdownController(IHubContext<NotificationHub> hubContext, IBusLiveUpdateService BusLiveUpdateService, ITrainLiveUpdateService TrainLiveUpdateService) //INotificationRepository notificationRepository)
        {
            _hubContext = hubContext;
            _BusLiveUpdateService = BusLiveUpdateService;
            _TrainLiveUpdateService = TrainLiveUpdateService;
            //_notificationRepository = notificationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBreakdown([FromBody] BreakdownUpdate update)
        {
            if (update == null)
            {
                return BadRequest("Invalid payload");
            }

            //Console.WriteLine($"Received update: {update.Message}, {update.Id}, {update.routNo}");

            //List<int> passengerIds;
            //if (!string.IsNullOrEmpty(update.routNo))
            //{
            // Handle bus logic
            // var passengerIds = await _BusLiveUpdateService.GetPassengerIdsForScheduledBusAsync(update.Id);
            // foreach (var passengerId in passengerIds)
            //{
            //  await _hubContext.Clients.User(passengerId.ToString()).SendAsync("ReceiveNotification", update.Message);
            //}
            //return Ok("ha ha succfuly");
            //}
            //else
            //{
            // Handle train logic
            //  var passengerIds = await _TrainLiveUpdateService.GetPassengerIdsForScheduledTrainAsync(update.Id);
            //foreach (var passengerId in passengerIds)
            //{
            //  await _hubContext.Clients.User(passengerId.ToString()).SendAsync("ReceiveNotification", update.Message);
            //}
            //return Ok("ha ha so sad");
            //}
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", update.Message,update.Id,update.routNo);

            // Logging or further processing can be added here
            //var notification = new Notification
            //{
                //Id = Guid.NewGuid(), // Generate a unique ID for each notification
               // Message = update.Message,
                //Timestamp = DateTime.UtcNow // Use UTC time for timestamp
         //   };

          //
            return Ok();
        }

       





    }

    public class BreakdownUpdate
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string routNo { get; set; }
    }
}

using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Payment.Infrastructure
{
    public class NotificationHub : Hub
    {
        //passngerid code
        // public override async Task OnConnectedAsync()
        //{
        //    var userId = Context.UserIdentifier; // Retrieve the user ID from the context if set
        //  await base.OnConnectedAsync();
        // }

        // public async Task SendBreakdownNotification(string userId, string message)
        //{
        //    await Clients.User(userId).SendAsync("ReceiveNotification", message);
        // }

        //=====trip id code================

       
           
        public async Task SendBreakdownNotification(string message,int Id,string routNo)
        {
            await Clients.All.SendAsync("ReceiveNotification", message,Id,routNo);
        }
    


}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TicketMate.Admin.Infastructure;


namespace TicketMate.Admin.Application.Services
{
    public class LocationHub: Hub
    { 
        private readonly LocationContext _context;
       
    // This method sends the bus location to all clients in the specified group (i.e., rideId group)
    public async Task SendLocation(int rideId, double latitude, double longitude)
    {
        await Clients.Group(rideId.ToString()).SendAsync("ReceiveLocation", latitude, longitude);
    }

    // This method adds the current connection to the specified group (i.e., rideId group)
    public async Task JoinRideGroup(string connectionId,int rideId)
    {
            try { 
        await Groups.AddToGroupAsync(Context.ConnectionId, rideId.ToString());
            Console.WriteLine($"Connection {connectionId} added to group {rideId}");
                }
            catch(Exception e)
            {
                Console.WriteLine($"Error in adding connection to group {rideId} : {e.Message}");
                throw;
            }

        }

        // This method removes the current connection from the specified group (i.e., rideId group)
        public async Task LeaveRideGroup(string connectionId, int rideId)
    {
            try
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, rideId.ToString());
                Console.WriteLine($"Connection {connectionId} removed from group {rideId}");

            }
            catch (Exception e)
            {
                Console.WriteLine($"error in leaveridegroup : {e.Message}");
            }
    }


}
}



using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;




namespace TicketMate.Admin.Application.Services
{
    public interface ILocationHub
    {
        // This method sends the bus location to all clients in the specified group (i.e., rideId group)
        public  Task SendLocation(int rideId, double latitude, double longitude);


        // This method adds the current connection to the specified group (i.e., rideId group)
        public Task JoinRideGroup(int rideId);

        // This method removes the current connection from the specified group (i.e., rideId group)
        public Task LeaveRideGroup(int rideId);

    }
}






   

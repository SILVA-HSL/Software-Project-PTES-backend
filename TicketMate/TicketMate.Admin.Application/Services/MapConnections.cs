using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Admin.Infastructure;



namespace TicketMate.Admin.Application.Services
{
    public class MapConnections : IMapConnections
    {
        private readonly userDbContext _context;

        public MapConnections(userDbContext context)
        {
            _context = context;
        }


        //to get the schedule id in the passenger side
        public int getBusScheduleId(int busBookingId)
        {
            try
            {
                var busScheduleId = _context.BusBookings.Where(b => b.BusBookingId == busBookingId)
                    .Select(b => b.BusScheduleId)
                    .FirstOrDefault();
                return (busScheduleId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public int getTrainScheduleid(int trainDriveId)
        {
            try
            {
                var trainScheduleId = _context.TrainBookings.Where(t => t.TrainBookingId == trainDriveId)
                    .Select(t => t.TrainScheduleId)
                    .FirstOrDefault();
                return (trainScheduleId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }
    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Dtos
{
    public class TrainRaliwayStations
    {
        [Key]
        public int Id { get; set; }
        public string TrainStationName { get; set; }

        public int TrainRailwayId { get; set; }
    }
}

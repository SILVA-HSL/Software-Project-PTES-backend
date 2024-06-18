using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Admin.Domain.Models
{
    public class LocationUpdateModel
    {
        public int RideId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

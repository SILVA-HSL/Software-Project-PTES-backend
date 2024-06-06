using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TicketMate.Admin.Infastructure
{
    public class LocationContext: DbContext
    {
        public LocationContext(DbContextOptions<LocationContext> options) : base(options)
        {
        }

        public DbSet<TicketMate.Admin.Domain.Models.LocationUpdateModel> LocationUpdates { get; set; }
    }
    

    
}

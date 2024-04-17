/*using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

*/
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using System.Reflection.Emit;



namespace TicketMate.Admin.Infastructure
{
      public class AuthDbContext : IdentityDbContext<IdentityUser>
   

    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            var adminRole = "797654bb-8e4f-4ae3-ac66-fbdc1c882291";
            var passengerRole = "0b7e7c7d-834b-473c-9072-19bbb3b3e892";
            var driverRole = "02c34beb-0e8c-45e8-ab14-f2d631c3f3e9";
            var ownerRole = "1ac2cb8f-a2d6-4617-8675-e495cc5f55e8";


            var roles = new List<IdentityRole>
            {
                new IdentityRole{
                    Id=adminRole,
                    ConcurrencyStamp=adminRole,
                    Name="Admin",
                    NormalizedName="ADMIN".ToUpper()
                },
                new IdentityRole
                {
                    Id=passengerRole,
                    ConcurrencyStamp=passengerRole,
                    Name="Passenger",
                    NormalizedName="PASSENGER".ToUpper()
                },
                new IdentityRole
                {
                    Id=driverRole,
                    ConcurrencyStamp=driverRole,
                    Name="Driver",
                    NormalizedName="DRIVER".ToUpper()
                },
                new IdentityRole
                {
                    Id=ownerRole,
                    ConcurrencyStamp=ownerRole,
                    Name="Owner",
                    NormalizedName="OWNER".ToUpper()
                }

            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}

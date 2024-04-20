using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Admin.Domain.Models
{
    public class userDataModel
    {

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }
        public string? DOB { get; set; }

        public string? NIC { get; set; }

        public string? ContactNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string? UserType { get; set; } = "passenger";
        public string? OwnVehicleType { get; set; }
        public string? DrivingLicenseNo { get; set; }


    }
}

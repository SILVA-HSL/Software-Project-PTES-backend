using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Booking.Domain.Models
{
    public class AspNetUsers
    {
        [Key]
       public string Id { get; set; }
       public string  UserName { get; set; }
    }
}

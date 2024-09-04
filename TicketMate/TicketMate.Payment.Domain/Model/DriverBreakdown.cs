using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Payment.Domain.Model
{
    public class DriverBreakdown
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DriverId { get; set; }
        [Required]
        public string BusNo { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int BreakdownStatus { get; set; }
    }
}

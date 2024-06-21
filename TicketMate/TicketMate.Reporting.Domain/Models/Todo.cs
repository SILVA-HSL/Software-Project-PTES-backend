using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; } // This is the primary key
         public required string Name { get; set; }
    }
}

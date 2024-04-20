using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Vehicle.Domain.Models
{
    public class RegisteredLocomotive
    {
        public int Id { get; set; }
        public string LocomotiveName { get; set; }
        public string LocomotiveNumber { get; set; }
        public string LocomotiveType { get; set; }
        public string LocomotiveModel { get; set; }
        public string LocomotiveCapacity { get; set; }
        public string LocomotiveSpeed { get; set; }
    }
}

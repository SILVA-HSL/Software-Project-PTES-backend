using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Dtos
{
    public class OwnerReportDTO
    {
        public int BusId { get; set; }
        public string VehicleOwner { get; set; }
        public string VehicleNo { get; set; }
        public decimal TotalIncome { get; set; }
        public int TotalPassengers { get; set; }
        public DateTime Date { get; set; }
        public double AverageRate { get; set; }
    }
}

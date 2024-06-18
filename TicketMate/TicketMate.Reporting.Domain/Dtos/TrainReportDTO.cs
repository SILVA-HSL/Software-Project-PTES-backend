using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Dtos
{
    public class TrainReportDTO
    {
        public List<int> ScheduleIds { get; set; }  // Change ScheduleId to List<int>
        public string TrainName { get; set; }
        public decimal TotalIncome { get; set; }
        public int TotalPassengers { get; set; }
        public decimal MonthlyPredictedIncome { get; set; }

        public double AverageRate { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
    }
}

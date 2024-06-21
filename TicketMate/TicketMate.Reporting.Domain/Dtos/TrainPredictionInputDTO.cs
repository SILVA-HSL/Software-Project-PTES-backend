using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Dtos
{
    public class TrainPredictionInputDTO
    {
        public string TrainName { get; set; }
        public int AcSeatCount { get; set; }
        public int NonAcSeatCount { get; set; }
        public double TicketPrice { get; set; }
        public int MonthlyBookedAcSeats { get; set; }
        public int MonthlyBookedNonAcSeats { get; set; }
        public int NumberOfRides { get; set; }
        public int WorkingDays { get; set; }
        public decimal PreviousMonthIncome { get; set; }
        public int TrainType { get; set; } // Assuming TrainType is represented as an integer (0 or 1)
    }
}

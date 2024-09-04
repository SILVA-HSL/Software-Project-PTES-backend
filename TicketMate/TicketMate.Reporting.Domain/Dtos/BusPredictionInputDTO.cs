using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Dtos
{
    public class BusPredictionInputDTO
    {
        public string BusNo { get; set; }
        public int BusId { get; set; }
        public string UserId { get; set; }

        public int SeatCount { get; set; }
        public int ACNonAC { get; set; }
        public double TicketPrice { get; set; }
        public int MonthlyBookedSeats { get; set; }
        public int NumberOfRides { get; set; }
        public int WorkingDays { get; set; }
        public double PreviousMonthIncome { get; set; }
        public double BaseMonthlyIncome { get; set; }
        public int AC { get; set; }
        public int SemiLux { get; set; }
        public int Normal { get; set; }
        public int Luxury { get; set; }
    }
}

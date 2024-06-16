using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Dtos
{
    public class BusPredictionOutputDTO
    {
        public String BusNo { get; set; }
        public decimal PredictedIncome { get; set; }
        public DateTime PredictionDate { get; set; }

    }
}

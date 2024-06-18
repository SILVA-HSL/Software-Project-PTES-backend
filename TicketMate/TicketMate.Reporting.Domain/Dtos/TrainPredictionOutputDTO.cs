using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Dtos
{
    public class TrainPredictionOutputDTO
    {
        public string TrainName { get; set; }
        public decimal PredictedIncome { get; set; }
        public DateTime PredictionDate { get; set; }
    }
}

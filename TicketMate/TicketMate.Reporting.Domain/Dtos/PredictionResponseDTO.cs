using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Dtos
{
    public class PredictionResponseDTO
    {
        public decimal predicted_income { get; set; }
        public decimal PredictedIncomeFormatted => Math.Round(predicted_income, 2);

    }
}

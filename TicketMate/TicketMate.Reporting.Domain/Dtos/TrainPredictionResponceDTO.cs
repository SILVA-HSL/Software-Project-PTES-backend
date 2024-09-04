using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Dtos
{
    public class TrainPredictionResponceDTO
    {

        public decimal predicted_income { get; set; }
        public decimal TrainPredictedIncomeFormatted => Math.Round(predicted_income, 2);
    }
}

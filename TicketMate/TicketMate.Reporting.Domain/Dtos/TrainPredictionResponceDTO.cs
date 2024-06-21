using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Dtos
{
    public class TrainPredictionResponceDTO
    {
        public decimal Trainpredicted_income { get; set; }
        public decimal TrainPredictedIncomeFormatted => Math.Round(Trainpredicted_income, 2);
    }
}

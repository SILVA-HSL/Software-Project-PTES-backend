using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Models
{
    public class DailyTrainPrediction
    {
        [Key]
        public int Id { get; set; }
        public string TrainName { get; set; }
      
        public decimal PredictedIncome { get; set; }
        public DateTime PredictionDate { get; set; }
    }
}

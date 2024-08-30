using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMate.Reporting.Domain.Models
{
    public class DailyBusPrediction
    {

        [Key]
        public int Id { get; set; }
        public string BusNo { get; set; }
        public int BusId { get; set; }
        public string UserId { get; set; }
        public decimal PredictedIncome { get; set; }
        public DateTime PredictionDate { get; set; }
    }
}

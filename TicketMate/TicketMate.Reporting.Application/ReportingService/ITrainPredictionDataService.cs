using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;

namespace TicketMate.Reporting.Application.ReportingService
{
    public interface ITrainPredictionDataService
    {
        public List<TrainPredictionInputDTO> GetPredictionDataForAllTrains();

    }
}

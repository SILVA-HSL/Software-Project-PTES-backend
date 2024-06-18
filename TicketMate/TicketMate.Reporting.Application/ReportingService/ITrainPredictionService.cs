using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;

namespace TicketMate.Reporting.Application.ReportingService
{
    public interface ITrainPredictionService
    {
        public Task<List<TrainPredictionOutputDTO>> GetTrainPredictedIncome(List<TrainPredictionInputDTO> inputDataList);
        public Task StoreTrainPredictionsAsync(List<TrainPredictionOutputDTO> predictions);
        public Task<bool> TrainPredictionsExistForTodayAsync();

    }
}

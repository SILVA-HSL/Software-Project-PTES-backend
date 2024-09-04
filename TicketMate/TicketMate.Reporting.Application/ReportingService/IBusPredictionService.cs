using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;
using TicketMate.Reporting.Domain.Models;

namespace TicketMate.Reporting.Application.ReportingService
{
    public interface IBusPredictionService
    {

        public Task<List<BusPredictionOutputDTO>> GetPredictedIncome(List<BusPredictionInputDTO> inputDataList);
        public Task StorePredictionsAsync(List<BusPredictionOutputDTO> predictions);
        public Task<bool> PredictionsExistForTodayAsync();

        //public Task<List<BusPredictionOutputDTO>> GetTodaysPredictionsAsync();

        //Task<List<PredictionOutputDTO>> GetPredictedIncome(PredictionInputDTO inputData);
        //public void StorePredictions(List<PredictionOutputDTO> predictions, string busNo);
        //public Task<List<PredictionOutputDTO>> FetchPredictedDataFromDatabase();


    }
}

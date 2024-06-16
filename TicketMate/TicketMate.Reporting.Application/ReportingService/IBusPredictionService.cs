using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;

namespace TicketMate.Reporting.Application.ReportingService
{
    public interface IBusPredictionService
    {

        public  Task<List<BusPredictionOutputDTO>> GetPredictedIncome(List<BusPredictionInputDTO> inputDataList);

        //Task<List<PredictionOutputDTO>> GetPredictedIncome(PredictionInputDTO inputData);
        //public void StorePredictions(List<PredictionOutputDTO> predictions, string busNo);
        //public Task<List<PredictionOutputDTO>> FetchPredictedDataFromDatabase();


    }
}

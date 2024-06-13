using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;
using static TicketMate.Reporting.Application.ReportingService.TrainReportingService;

namespace TicketMate.Reporting.Application.ReportingService
{
    public interface ITrainReportingService

    {
        public  Task<List<TrainReportDTO>> GenerateTrainReportAsync(string userId, DateFilter dateFilter);
        public List<string> GetTrainOwnerUserIds();



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;
using TicketMate.Reporting.Domain.Models;

namespace TicketMate.Reporting.Application.ReportingService
{
    public interface IAdminReportingService
    {
      
        public AdminReportDTO GetStatistics(string userId, DateTime startDate, DateTime endDate);

        public List<string> GetBusOwnerUserIds();
        public string GetTotalPredictedIncomeForUser(string userId);

    }

}



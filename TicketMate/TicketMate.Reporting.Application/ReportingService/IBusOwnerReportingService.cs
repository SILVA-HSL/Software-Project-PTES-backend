using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;

namespace TicketMate.Reporting.Application.ReportingService
{
    public interface IBusOwnerReportingService
    {
        Task<List<OwnerReportDTO>> GetOwnerReportAsync(string userId);
        Task<List<OwnerReportDTO>> GetMonthlyOwnerReportAsync(string userId);
        Task<List<OwnerReportDTO>> GetQuarterlyOwnerReportAsync(string userId);
        Task<List<OwnerReportDTO>> GetYearlyOwnerReportAsync(string userId);
    }
}

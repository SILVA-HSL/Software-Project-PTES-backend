using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Models;
using TicketMate.Reporting.Infrastructure;

namespace TicketMate.Reporting.Application.ReportingService
{
    public class ReportingService : IReportingService
    {
        private readonly ReportingDbContext _context;

        public ReportingService(DbContextOptions<ReportingDbContext> dbContextOptions)
        {
            _context = new ReportingDbContext(dbContextOptions);
        }

        public List<Todo> GetTodos()
        {
            return _context.Todos.ToList();
        }
    }
}
//using ReportModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TicketMate.Reporting.Infrastructure;
//using ReportModels;

//namespace ReportServices
//{
//    public class ReportSqlServerService : IReportRepository
//    {
//        private readonly ReportDbContext _context = new ReportDbContext();
//        public List<AdminReport> GenerateSampleData()
//        {
//            return _context.AdminReports.ToList();
//        }
//    }
//}

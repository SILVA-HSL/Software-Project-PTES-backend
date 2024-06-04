using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Models;

namespace TicketMate.Reporting.Application.ReportingService
{
    public interface IReportingService
    {
        public List<Todo> GetTodos();
    }

}
//using ReportModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ReportServices
//{
//    public interface IReportRepository
//    {
//        public List<AdminReport> GenerateSampleData();

//    }
//}


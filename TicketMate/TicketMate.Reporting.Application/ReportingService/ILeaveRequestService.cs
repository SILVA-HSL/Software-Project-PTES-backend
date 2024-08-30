using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;
using TicketMate.Reporting.Domain.Models;

namespace TicketMate.Reporting.Application.ReportingService
{
    public interface ILeaveRequestService
    {
        Task<IEnumerable<LeaveRequest>> GetAllAsync();
        Task<IEnumerable<LeaveRequest>> GetAllForUserAsync(string userId);

        Task<LeaveRequest> GetByIdAsync(int id);
        Task<LeaveRequest> CreateAsync(LeaveRequestDto leaveRequestDto);
        Task<LeaveRequest> UpdateAsync(int id, LeaveRequestDto leaveRequestDto);


        public Task<IEnumerable<int>> GetDriverIdsByBusOwnerAsync(string busOwnerId);
        public Task<IEnumerable<LeaveRequest>> GetLeaveRequestsByDriverIdsAsync(IEnumerable<int> driverIds);

        Task<bool> UpdateLeaveRequestStatus(int id, string status);
        //public  Task<bool> CancelLeaveRequest(int id);


        public Task<IEnumerable<int>> GetDriverIdsByTrainOwnerAsync(string trainOwnerId);


    }
}

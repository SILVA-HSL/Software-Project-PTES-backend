using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMate.Reporting.Domain.Dtos;
using TicketMate.Reporting.Domain.Models;
using TicketMate.Reporting.Infrastructure;

namespace TicketMate.Reporting.Application.ReportingService
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ReportingDbContext _context;

        public LeaveRequestService(ReportingDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<LeaveRequest>> GetAllAsync()
        {
            return await _context.LeaveRequests.ToListAsync();
        }

        public async Task<IEnumerable<LeaveRequest>> GetAllForUserAsync(string userId)
        {
            var leaveRequests = await _context.LeaveRequests
      .Where(lr => lr.UserId == userId)
      .ToListAsync();

            // Convert StartDate to DateTime and sort in-memory
            leaveRequests = leaveRequests
                .OrderByDescending(lr => DateTime.Parse(lr.StartDate))
                .ToList();

            return leaveRequests;
        }
        public async Task<LeaveRequest> GetByIdAsync(int id)
        {
            return await _context.LeaveRequests.FindAsync(id);
        }

        public async Task<LeaveRequest> CreateAsync(LeaveRequestDto leaveRequestDto)
        {
            var leaveRequest = new LeaveRequest
            {
                Date = DateTime.Now.ToString("yyyy-MM-dd"), // or use another property if necessary
                Reason = leaveRequestDto.Reason,
                OtherReason = leaveRequestDto.OtherReason,
                StartDate = leaveRequestDto.StartDate,
                EndDate = leaveRequestDto.EndDate,
                TotalDays = leaveRequestDto.TotalDays,
                FamilyAndMedical = leaveRequestDto.FamilyAndMedical,
                FuneralRelationship = leaveRequestDto.FuneralRelationship,
                Name = leaveRequestDto.Name,
                UserId = leaveRequestDto.UserId,
                Status = leaveRequestDto.Status

            };

            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task<LeaveRequest> UpdateAsync(int id, LeaveRequestDto leaveRequestDto)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest == null)
            {
                return null;
            }

            leaveRequest.Reason = leaveRequestDto.Reason;
            leaveRequest.OtherReason = leaveRequestDto.OtherReason;
            leaveRequest.StartDate = leaveRequestDto.StartDate;
            leaveRequest.EndDate = leaveRequestDto.EndDate;
            leaveRequest.TotalDays = leaveRequestDto.TotalDays;
            leaveRequest.FamilyAndMedical = leaveRequestDto.FamilyAndMedical;
            leaveRequest.FuneralRelationship = leaveRequestDto.FuneralRelationship;
            leaveRequest.Name = leaveRequestDto.Name;
            leaveRequest.UserId = leaveRequestDto.UserId;
            leaveRequest.Status = leaveRequestDto.Status;

            await _context.SaveChangesAsync();
            return leaveRequest;
        }


        public async Task<IEnumerable<int>> GetDriverIdsByBusOwnerAsync(string busOwnerId)
        {
            return await _context.ScheduledBuses
                .Where(sb => sb.UserId == busOwnerId)
                .Select(sb => sb.DriverId)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<LeaveRequest>> GetLeaveRequestsByDriverIdsAsync(IEnumerable<int> driverIds)
        {
            var driverIdsAsStrings = driverIds.Select(id => id.ToString()).ToList();

            var leaveRequests = await _context.LeaveRequests
            .Where(lr => driverIdsAsStrings.Contains(lr.UserId))
                .ToListAsync();

            leaveRequests = leaveRequests
                .OrderByDescending(lr => DateTime.Parse(lr.StartDate))
                .ToList();

            return leaveRequests;
        }

        public async Task<bool> UpdateLeaveRequestStatus(int id, string status)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest == null) return false;

            leaveRequest.Status = status;
            _context.LeaveRequests.Update(leaveRequest);
            await _context.SaveChangesAsync();
            return true;
        }
        // Implement the new method
        //public async Task<bool> CancelLeaveRequest(int id)
        //{
        //    return await UpdateLeaveRequestStatus(id, "Cancelled");
        //}
        public async Task<IEnumerable<int>> GetDriverIdsByTrainOwnerAsync(string trainOwnerId)
        {
            return await _context.ScheduledTrains
                .Where(sb => sb.UserId == trainOwnerId)
                .Select(sb => sb.TrainDriverId)
                .Distinct()
                .ToListAsync();
        }
    }
}


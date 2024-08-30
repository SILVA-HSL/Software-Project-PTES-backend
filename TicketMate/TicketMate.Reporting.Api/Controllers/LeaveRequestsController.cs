using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Reporting.Application.ReportingService;
using TicketMate.Reporting.Domain.Dtos;
using TicketMate.Reporting.Domain.Models;
using TicketMate.Reporting.Infrastructure;

namespace TicketMate.Reporting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;

        public LeaveRequestsController(ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetAll()
        {
            var leaveRequests = await _leaveRequestService.GetAllAsync();
            return Ok(leaveRequests);
        }


        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetByUserId(string userId)
        {
            var leaveRequests = await _leaveRequestService.GetAllForUserAsync(userId);
            if (leaveRequests == null || !leaveRequests.Any())
            {
                return NotFound();
            }

            return Ok(leaveRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequest>> GetById(int id)
        {
            var leaveRequest = await _leaveRequestService.GetByIdAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            return Ok(leaveRequest);
        }
        [HttpPost]
        public async Task<ActionResult<LeaveRequest>> Create(LeaveRequestDto leaveRequestDto)
        {
            try
            {
                var leaveRequest = await _leaveRequestService.CreateAsync(leaveRequestDto);
                return CreatedAtAction(nameof(GetById), new { id = leaveRequest.Id }, leaveRequest);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LeaveRequest>> Update(int id, LeaveRequestDto leaveRequestDto)
        {
            var leaveRequest = await _leaveRequestService.UpdateAsync(id, leaveRequestDto);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            return Ok(leaveRequest);
        }


        [HttpGet("busowner/{busOwnerId}/leaverequests")]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetLeaveRequestsByBusOwner(string busOwnerId)
        {
            var driverIds = await _leaveRequestService.GetDriverIdsByBusOwnerAsync(busOwnerId);

            if (!driverIds.Any())
            {
                return NotFound();
            }

            var leaveRequests = await _leaveRequestService.GetLeaveRequestsByDriverIdsAsync(driverIds);

            return Ok(leaveRequests);
        }

        [HttpPost("{id}/accept")]
        public async Task<IActionResult> AcceptLeaveRequest(int id)
        {
            var result = await _leaveRequestService.UpdateLeaveRequestStatus(id, "Accepted");
            if (result)
            {
                return Ok(new { message = "Leave request accepted." });
            }
            return BadRequest(new { message = "Failed to accept leave request." });
        }

        [HttpPost("{id}/reject")]
        public async Task<IActionResult> RejectLeaveRequest(int id)
        {
            var result = await _leaveRequestService.UpdateLeaveRequestStatus(id, "Rejected");
            if (result)
            {
                return Ok(new { message = "Leave request rejected." });
            }
            return BadRequest(new { message = "Failed to reject leave request." });
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> CancelLeaveRequest(int id)
        {
            var result = await _leaveRequestService.UpdateLeaveRequestStatus(id, "Cancelled");
            if (result)
            {
                return Ok(new { message = "Leave request cancelled." });
            }
            return BadRequest(new { message = "Failed to cancel leave request." });
        }

        //[HttpPost("{id}/cancel")]
        //public async Task<IActionResult> CancelLeaveRequest(int id)
        //{
        //    var result = await _leaveRequestService.CancelLeaveRequest(id);
        //    if (result)
        //    {
        //        return Ok(new { message = "Leave request cancelled." });
        //    }
        //    return BadRequest(new { message = "Failed to cancel leave request." });
        //}

        [HttpGet("trainowner/{trainOwnerId}/leaverequests")]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetLeaveRequestsByTrainOwner(string trainOwnerId)
        {
            var driverIds = await _leaveRequestService.GetDriverIdsByTrainOwnerAsync(trainOwnerId);

            if (!driverIds.Any())
            {
                return NotFound();
            }

            var leaveRequests = await _leaveRequestService.GetLeaveRequestsByDriverIdsAsync(driverIds);

            return Ok(leaveRequests);
        }
    }

}


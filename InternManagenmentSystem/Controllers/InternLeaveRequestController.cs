using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternManagementSystem.DataRepository;
using InternManagementSystem.Models;

namespace InternManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternLeaveRequestController : ControllerBase
    {
        private readonly InternDbContext internDbContext;

        public InternLeaveRequestController(InternDbContext internDbContext)
        {
            this.internDbContext = internDbContext;
        }

        // Get All Leave Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InternLeaveRequest>>> GetInternLeaveRequest()
        {
            var leaveRequests = await internDbContext.InternLeaveRequest.ToListAsync();
            return Ok(leaveRequests);
        }

        // Get Leave Request by id
        [HttpGet("{id}")]
        public async Task<ActionResult<InternLeaveRequest>> GetInternLeaveRequest(int id)
        {
            var internLeaveRequest = await internDbContext.InternLeaveRequest.FindAsync(id);

            if (internLeaveRequest != null)
            {
                return internLeaveRequest;
            }

            return NotFound("Intern Leave Request Details Not Found With id" + id);
        }

        // Post a Leave Request

        [HttpPost]
        public async Task<ActionResult<InternLeaveRequest>> PostInternLeaveRequest(InternLeaveRequest internLeaveRequest)
        {
            try
            {
                internDbContext.InternLeaveRequest.Add(internLeaveRequest);
                await internDbContext.SaveChangesAsync();

                return CreatedAtAction("GetInternLeaveRequest", new { id = internLeaveRequest.SNo }, internLeaveRequest);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Update a Leave Request by id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInternLeaveRequest(int id, InternLeaveRequest UpdateInternLeaveRequest)
        {
            try
            {
                var leaveRequest = await internDbContext.InternLeaveRequest.FindAsync(id);
                if (leaveRequest != null)
                {
                    leaveRequest.LeaveDate = UpdateInternLeaveRequest.LeaveDate;
                    leaveRequest.LeaveReason = UpdateInternLeaveRequest.LeaveReason;
                    leaveRequest.LeaveType = UpdateInternLeaveRequest.LeaveType;
                    await internDbContext.SaveChangesAsync();

                    return Ok("Intern LeaveRequest Updated with id: " + id);
                }
                return NotFound("Intern LeaveRequest Details Not Found with id: " + id);

            }
            catch (Exception)
            {

                throw;
            }
        }
        // Delete a Leave Request
        [HttpDelete("{id}")]
        public async Task<ActionResult<InternLeaveRequest>> DeleteInternLeaveRequest(int id)
        {
            try
            {
                var internLeaveRequest = await internDbContext.InternLeaveRequest.FindAsync(id);
                if (internLeaveRequest != null)
                {
                    internDbContext.InternLeaveRequest.Remove(internLeaveRequest);
                    await internDbContext.SaveChangesAsync();

                    return Ok("Intern Leave Request Deleted With Id:" + id);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return NotFound("Intern Leave Request Details Not Found With Id:" + id);
        }
    }
}

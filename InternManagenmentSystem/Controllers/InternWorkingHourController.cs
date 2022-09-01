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
    public class InternWorkingHourController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly InternDbContext internDbContext;

        public InternWorkingHourController(InternDbContext internDbContext)
        {
            this.internDbContext = internDbContext;
        }

        // Get all Interns WorkingHours Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InternWorkingHour>>> GetInternWorkingHour()
        {
            var allRecords = await internDbContext.InternWorkingHour.ToListAsync();
            log.Info("All Intern WorkingHour Details Displayed Successfully");
            return allRecords;
        }

        // Get an Intern Working Hours Details Based on id
        [HttpGet("{id}")]
        public async Task<ActionResult<InternWorkingHour>> GetInternWorkingHour(int id)
        {
            try
            {
                var internWorkingHour = await internDbContext.InternWorkingHour.FindAsync(id);

                if (internWorkingHour != null)
                {
                    log.Info("Intern WorkingHour Details By id Displayed Successfully");

                    return internWorkingHour;
                }
                else
                {

                    return NotFound("Intern working Hour Details Not Found with Entered Id: " + id);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        // Post an Intern working Hour Details
        [HttpPost]
        public async Task<ActionResult<InternWorkingHour>> PostInternWorkingHour(InternWorkingHour internWorkingHour)
        {
            internDbContext.InternWorkingHour.Add(internWorkingHour);
            await internDbContext.SaveChangesAsync();
            log.Info("Intern WorkingHour Details Posted Successfully");

            return CreatedAtAction("GetInternWorkingHour", new { InternId = internWorkingHour.SNo }, internWorkingHour);
        }


        // Update an Intern WorkingHour Details
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInternWorkingHour(int id, InternWorkingHour UpdateInternWorkingHour)
        {
            try
            {
                var updateWorkingHour = await internDbContext.InternWorkingHour.FindAsync(id);
                if (updateWorkingHour != null)
                {
                    updateWorkingHour.CompanyMonthlyWorkingHours = UpdateInternWorkingHour.CompanyMonthlyWorkingHours;
                    updateWorkingHour.InternMonthlyWorkingHours = UpdateInternWorkingHour.InternMonthlyWorkingHours;

                    await internDbContext.SaveChangesAsync();
                    log.Info("Intern WorkingHour Details By id Updated Successfully");

                    return Ok("Intern Working Hour Details Updated with id: " + id);
                }

                return NotFound("Intern Working Hour Details Not Found with id: " + id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        //  Delete an Intern WorkingHour Details
        [HttpDelete("{id}")]
        public async Task<ActionResult<InternWorkingHour>> DeleteInternWorkingHour(int id)
        {
            try
            {

                var internWorkingHour = await internDbContext.InternWorkingHour.FindAsync(id);
                if (internWorkingHour == null)
                {
                    internDbContext.InternWorkingHour.Remove(internWorkingHour);
                    await internDbContext.SaveChangesAsync();
                    log.Info("Intern WorkingHour Details By id Deleted Successfully");

                    return internWorkingHour;
                }
                else
                {
                    log.Info("Intern WorkingHour Details By id Not Deleted  Successfully");

                    return NotFound("Intern Working Hour Details Not Found With InternId: " + id);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
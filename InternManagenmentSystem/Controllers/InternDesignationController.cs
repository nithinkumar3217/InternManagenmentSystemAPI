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
    public class InternDesignationController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly InternDbContext internDbContext;

        public InternDesignationController(InternDbContext internDbContext)
        {
            this.internDbContext = internDbContext;
        }

        // Get All InternDesignationDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InternDesignation>>> GetInternDesignation()
        {
            var designations = await internDbContext.InternDesignation.ToListAsync();
            log.Info("Intern designation Details Displayed Successfully");
            return Ok(designations);
        }

        // Get InternDesignationDetails with Id
        [HttpGet("{id}")]
        public async Task<ActionResult<InternDesignation>> GetInternDesignation(int id)
        {
            try
            {

                var internDesignation = await internDbContext.InternDesignation.FindAsync(id);

                if (internDesignation != null)
                {
                    log.Info("Intern Designation Details By id Displayed successfully");
                    return internDesignation;
                }
                else
                {
                    return NotFound("Intern DesignationDetails Not Found with Entered Id: " + id);
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        // Post Intern Designation Details
        [HttpPost]
        public async Task<ActionResult<InternDesignation>> PostInternDesignation(InternDesignation internDesignation)
        {
            internDbContext.InternDesignation.Add(internDesignation);
            await internDbContext.SaveChangesAsync();
            log.Info("Intern Designation Details Posted Successfully");
            return CreatedAtAction("GetInternDesignation", new { id = internDesignation.SNo }, internDesignation);
        }

        //Update Intern Designation Details
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInternDesignation(int id, InternDesignation UpdateInternDesignation)
        {
            try
            {
                var updatedesignation = await internDbContext.InternDesignation.FindAsync(id);
                if (updatedesignation != null)
                {
                    updatedesignation.DesignationId = UpdateInternDesignation.DesignationId;
                    updatedesignation.DesignationName = UpdateInternDesignation.DesignationName;
                    updatedesignation.DepartMent = UpdateInternDesignation.DepartMent;
                    await internDbContext.SaveChangesAsync();
                    log.Info("Intern Designation Details Updated Successfully");
                    return Ok("Intern Designation Details Updated with id: " + id);
                }
                return NotFound("Intern Designation Details Not Found with id: " + id);
            }
            catch (Exception)
            {

                throw;
            }

        }


        // Delete An Intern Designation Details  based on id
        [HttpDelete("{id}")]
        public async Task<ActionResult<InternDesignation>> DeleteInternDesignation(int id)
        {
            try
            {
                var internDesignation = await internDbContext.InternDesignation.FindAsync(id);
                if (internDesignation != null)
                {
                    internDbContext.InternDesignation.Remove(internDesignation);
                    await internDbContext.SaveChangesAsync();
                    log.Info("InternDesignation Details By id Deleted Successfully ");
                    return Ok("Designation Details Deleted with DesignationId:" + id);
                }

                return NotFound("Intern Designation Details Not Found With DesignationId: " + id);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
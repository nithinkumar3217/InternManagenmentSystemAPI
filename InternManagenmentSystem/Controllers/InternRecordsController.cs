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
    public class InternRecordsController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly InternDbContext internDbContext;

        public InternRecordsController(InternDbContext internDbContext)
        {
            this.internDbContext = internDbContext;
        }

        // Get All InternRecords
        [HttpGet]
        public async Task<IActionResult> GetInternRecord()
        {
            var InternRecord = await internDbContext.InternRecord.ToListAsync();
            log.Info("All intern Records Displayed Successfully");
            return Ok(InternRecord);
        }

        //Get an Intern Record By InternId
        [HttpGet("{InternId}")]
        public async Task<ActionResult<InternRecord>> GetInternRecord(int InternId)
        {
            var internRecord = await internDbContext.InternRecord.FindAsync(InternId);

            if (internRecord != null)
            {
                log.Info("intern Record By id Displayed Successfully");
                return internRecord;
            }

            return NotFound("InternRecord Not Found With InternId: " + InternId);
        }

        //Post An InternRecord
        [HttpPost]
        public async Task<IActionResult> AddInternRecord(InternRecord internRecord)
        {

            await internDbContext.InternRecord.AddAsync(internRecord);
            await internDbContext.SaveChangesAsync();
            log.Info("Intern Posted Successfully");
            return CreatedAtAction("GetInternRecord", new { id = internRecord.InternId }, internRecord);
        }

        // Update An InternRecord By InternId

        [HttpPut("{InternId}")]
        public async Task<IActionResult> UpdateInternRecord(int InternId, InternRecord UpdateInternRecord)
        {
            try
            {
                var internRecord = await internDbContext.InternRecord.FindAsync(InternId);
                if (internRecord != null)
                {
                    internRecord.InternName = UpdateInternRecord.InternName;
                    internRecord.Mobile = UpdateInternRecord.Mobile;
                    internRecord.Email = UpdateInternRecord.Email;
                    internRecord.Adress = UpdateInternRecord.Adress;
                    await internDbContext.SaveChangesAsync();
                    log.Info("Intern Record By InternId Updated Successfully");
                    return Ok("Intern Details Updated with InternId: " + InternId);
                }
                return NotFound("Intern Details Not Found with InternId: " + InternId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // Delete An Intern Designation Details based on id
        [HttpDelete("{InternId}")]
        public async Task<ActionResult<InternRecord>> DeleteInternRecord(int InternId)
        {
            try
            {
                var internRecord = await internDbContext.InternRecord.FindAsync(InternId);
                if (internRecord != null)
                {
                    internDbContext.InternRecord.Remove(internRecord);
                    await internDbContext.SaveChangesAsync();
                    log.Info("Intern Record By InternId Deleted Successfully");
                    return Ok("Intern Record Deleted With Intern id: " + InternId);
                }

                return NotFound("InternRecord Not Found With InternId: " + InternId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
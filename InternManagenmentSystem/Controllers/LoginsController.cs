﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternManagementSystem.DataRepository;
using InternManagementSystem.Models;

namespace InternManagenmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly InternDbContext internDbContext;

        public LoginsController(InternDbContext internDbContext)
        {
            this.internDbContext = internDbContext;
        }

        // GET: api/Logins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLogins()
        {
            return await internDbContext.Logins.ToListAsync();
        }


        // PUT: api/Logins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin(int id, Login login)
        {
            if (id != login.SNo)
            {
                return BadRequest();
            }

            internDbContext.Entry(login).State = EntityState.Modified;

            try
            {
                await internDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Logins
       
        [HttpPost]
        public async Task<ActionResult<Login>> PostLogin(Login login)
        {
            internDbContext.Logins.Add(login);
            await internDbContext.SaveChangesAsync();

            return CreatedAtAction("GetLogin", new { id = login.SNo }, login);
        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Login>> DeleteLogin(int id)
        {
            var login = await internDbContext.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            internDbContext.Logins.Remove(login);
            await internDbContext.SaveChangesAsync();

            return login;
        }

        private bool LoginExists(int id)
        {
            return internDbContext.Logins.Any(e => e.SNo == id);
        }
    }
}

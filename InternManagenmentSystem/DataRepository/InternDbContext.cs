using InternManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternManagementSystem.DataRepository
{
    public class InternDbContext : DbContext
    {
        public InternDbContext()
        {
        }

        public InternDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<InternRecord> InternRecord { get; set; }
        public DbSet<InternDesignation> InternDesignation { get; set; }
        public DbSet<InternLeaveRequest> InternLeaveRequest { get; set; }
        public DbSet<InternWorkingHour> InternWorkingHour { get; set; }

        public DbSet<Register> Registers { set; get; }
        public DbSet<Login> Logins { get; set; }
    }
}

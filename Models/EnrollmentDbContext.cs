using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD09.Models
{
    public class EnrollmentDbContext : DbContext
    {
        public DbSet<Enrollment> Enrolment { get; set; }

        public EnrollmentDbContext() { }

        public EnrollmentDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}

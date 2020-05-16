using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD09.Models
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Student { get; set; }

        public StudentDbContext() { }

        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD09.Models
{
    public class StudiesDbContext : DbContext
    {
        public DbSet<Studies> Studies { get; set; }

        public StudiesDbContext() { }

        public StudiesDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}

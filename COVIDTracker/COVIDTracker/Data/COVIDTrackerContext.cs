using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using COVIDTracker.Models;

namespace COVIDTracker.Data
{
    public class COVIDTrackerContext : DbContext
    {
        public COVIDTrackerContext (DbContextOptions<COVIDTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<COVIDTracker.Models.Venues> Venues { get; set; }

        public DbSet<COVIDTracker.Models.Users> Users { get; set; }
    }
}

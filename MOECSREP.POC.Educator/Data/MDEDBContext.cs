using Microsoft.EntityFrameworkCore;
using MOECSREP.POC.Educator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOECSREP.POC.Educator.Data
{
    public class MDEDBContext : DbContext
    {
        public MDEDBContext(DbContextOptions<MDEDBContext> options) : base(options)
        {
        }

        public DbSet<MOECSREP.POC.Educator.Models.Educator> Educators { get; set; }
        public DbSet<MOECSREP.POC.Educator.Models.Education> Educations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map entities to tables  
            modelBuilder.Entity<MOECSREP.POC.Educator.Models.Educator>().ToTable("Educator");
            modelBuilder.Entity<MOECSREP.POC.Educator.Models.Education>().ToTable("Education");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentitySample.Models
{
    public class IdentitySampleContext : IdentityDbContext<ApplicationUser>
    {
        public IdentitySampleContext(DbContextOptions<IdentitySampleContext> options) : base(options)
        {
        }

        public DbSet<IdentitySample.Models.Location> Location { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Location>().ToTable("Location");

        }
    }
}

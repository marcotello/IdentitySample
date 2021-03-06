﻿using IdentitySample.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentitySample.Data
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

        public DbSet<IdentitySample.Models.Reservation> Reservation { get; set; }
    }
}

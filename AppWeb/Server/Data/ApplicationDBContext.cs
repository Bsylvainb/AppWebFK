using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AppWeb.Shared.Models;

namespace AppWeb.Server.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<ActionItem> ActionItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionItem>()
                        .HasOne(d => d.Developer)
                        .WithMany(d => d.ActionItems);
                   
        }

    }

   

}
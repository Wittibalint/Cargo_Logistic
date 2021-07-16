using Logistic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logistic.Data
{
    public class LogisticDbContext: DbContext
    {
        private ILogger<LogisticDbContext> Logger { get; }
        public LogisticDbContext(ILogger<LogisticDbContext> logger, DbContextOptions<LogisticDbContext> options) : base(options)
        {
            Logger = logger;
        }
        

        public DbSet<User> Users { get; set; }
        public DbSet<Depot> Depots { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.Property(t => t.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Depot>(depot =>
            {
                depot.Property(t => t.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Order>(order =>
            {
                order.Property(t => t.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Vehicle>(vehicle =>
            {
                vehicle.Property(t => t.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<User>()
                .HasMany(c => c.Orders)
                .WithOne(e => e.User);

            modelBuilder.Entity<Order>()
                .HasOne(c => c.User)
                .WithMany(e => e.Orders);

            modelBuilder.Entity<Vehicle>()
                .HasMany(c => c.Orders)
                .WithOne(e => e.Vehicle);

            modelBuilder.Entity<Order>()
                .HasOne(c => c.Vehicle)
                .WithMany(e => e.Orders);

            modelBuilder.Entity<Depot>()
                .HasMany(c => c.Vehicles)
                .WithOne(e => e.Depot);

            modelBuilder.Entity<Vehicle>()
                .HasOne(c => c.Depot)
                .WithMany(e => e.Vehicles);
        }
    }
}

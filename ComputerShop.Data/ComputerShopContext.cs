using ComputerShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ComputerShop.Data
{
    public class ComputerShopContext : DbContext
    {
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<ConfigurationType> ConfigurationTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LaptopConfiguration> LaptopConfigurations { get; set; }

        public ComputerShopContext(DbContextOptions<ComputerShopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LaptopConfiguration>()
                .HasOne(l => l.Laptop)
                .WithMany(c => c.LaptopConfigurations)
                .HasForeignKey(c => c.LaptopId);

            modelBuilder.Entity<LaptopConfiguration>()
                .HasOne(l => l.Configuration)
                .WithMany(o => o.Laptops)
                .HasForeignKey(l => l.ConfigurationId);

            modelBuilder.Entity<Configuration>()
                .HasOne(l => l.ConfigurationType)
                .WithMany(o => o.Configurations)
                .HasForeignKey(l => l.ConfigurationTypeId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Laptop)
                .WithMany(l => l.Orders);

            Guid colorTypeId = Guid.NewGuid();
            modelBuilder.Entity<ConfigurationType>()
                .HasData(
                    new ConfigurationType[]
                    {
                        new ConfigurationType { Id = colorTypeId, Name = "Color" },
                        new ConfigurationType { Id = Guid.NewGuid(), Name = "Ram" },
                        new ConfigurationType { Id = Guid.NewGuid(), Name = "Processor" }
                    });

            modelBuilder.Entity<Configuration>()
                .HasData(
                new Configuration[]
                {
                    new Configuration { Id = Guid.NewGuid(), ConfigurationTypeId = colorTypeId, Value = "Red" }
                });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JasperGreen.Models.SeedData;
using Microsoft.EntityFrameworkCore;

namespace JasperGreen.Models
{
    public class JasperGreenContext : DbContext
    {
        public JasperGreenContext(DbContextOptions<JasperGreenContext> options)
            : base(options)
        { }

        public DbSet<Crew> Crews { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<ProvidedService> ProvidedServices { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed initial data
            modelBuilder.ApplyConfiguration(new SeedCrew());
            modelBuilder.ApplyConfiguration(new SeedCustomer());
            modelBuilder.ApplyConfiguration(new SeedEmployee());
            modelBuilder.ApplyConfiguration(new SeedPayment());
            modelBuilder.ApplyConfiguration(new SeedProperty());
            modelBuilder.ApplyConfiguration(new SeedProvidedService());
            modelBuilder.ApplyConfiguration(new SeedState());

            // Property: set foreign keys. one-to-many relationship between Customer and Property
            modelBuilder.Entity<Property>().HasOne(p => p.Customer)
                .WithMany(c => c.Properties)
                .HasForeignKey(p => p.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            //Payment: set foreign keys. one-to-many relationship between Customer and Payment
            modelBuilder.Entity<Payment>().HasOne(pa => pa.Customer)
                .WithMany(c => c.Payments)
                .HasForeignKey(pa => pa.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            //Provided Services: set foreign keys.
            //one-to-many relationship between Crew and Provided Service
            modelBuilder.Entity<ProvidedService>().HasOne(ps => ps.Crew)
                .WithMany(cr => cr.ProvidedServices)
                .HasForeignKey(ps => ps.CrewID)
                .OnDelete(DeleteBehavior.Restrict);
            //one-to-many relationship between Customer and Provided Service
            modelBuilder.Entity<ProvidedService>().HasOne(ps => ps.Customer)
                .WithMany(c => c.ProvidedServices)
                .HasForeignKey(ps => ps.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);
            //one-to-many relationship between Property and Provided Service
            modelBuilder.Entity<ProvidedService>().HasOne(ps => ps.Property)
                .WithMany(p => p.ProvidedServices)
                .HasForeignKey(ps => ps.PropertyID)
                .OnDelete(DeleteBehavior.Restrict);
            //one-to-many relationship between Payment and Provided Service
            //modelBuilder.Entity<ProvidedService>().HasOne(ps => ps.Payment)
            //    .WithMany(pa => pa.ProvidedServices)
            //    .HasForeignKey(ps => ps.PaymentID)
            //    .OnDelete(DeleteBehavior.Restrict);

            //one to many relationship between employee and Crew forman
            modelBuilder.Entity<Crew>()
                .HasOne(e => e.EmpForeman)
                .WithMany(c => c.Crews)
                .HasForeignKey(c=>c.CrewForeman)
                .OnDelete(DeleteBehavior.Restrict);
            //one to many relationship between employee and crew member 1
            modelBuilder.Entity<Crew>()
                .HasOne(e => e.EmpMember1)
                .WithMany(c => c.Member1)
                .HasForeignKey(c=>c.CrewMember1)
                .OnDelete(DeleteBehavior.Restrict);
            //one to many relationship between employee and Crew member 2
            modelBuilder.Entity<Crew>()
                .HasOne(e => e.EmpMember2)
                .WithMany(c => c.Member2)
                .HasForeignKey(c=>c.CrewMember2)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JasperGreen.Models.SeedData
{
    internal class SeedCustomer : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasData(
                new Customer { CustomerID = 101, Name = "Steven Grant", BillingAddress = "616 Avengers St", BillingCity = "College Station", StateID = "TX", BillingZIP = "77840", PhoneNumber = "979-777-1111" },
                new Customer { CustomerID = 102, Name = "Marc Spector", BillingAddress = "617 Avengers St", BillingCity = "College Station", StateID = "TX", BillingZIP = "77840", PhoneNumber = "979-000-1212" },
                new Customer { CustomerID = 103, Name = "Kate Bishop", BillingAddress = "120 Marvel Rd", BillingCity = "College Station", StateID = "TX", BillingZIP = "77843", PhoneNumber = "979-123-4567" },
                new Customer { CustomerID = 104, Name = "Carol Danvers", BillingAddress = "124 Marvel Rd", BillingCity = "College Station", StateID = "TX", BillingZIP = "77843", PhoneNumber = "979-222-2222" },
                new Customer { CustomerID = 105, Name = "James Rhodes", BillingAddress = "111 Hero Ln", BillingCity = "College Station", StateID = "TX", BillingZIP = "77844", PhoneNumber = "979-555-4444" }
            );
        }
    }
}

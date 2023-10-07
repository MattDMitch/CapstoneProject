using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JasperGreen.Models.SeedData
{
    internal class SeedPayment : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.HasData(
                new Payment { PaymentID = 11101, CustomerID = 101, PaymentDate = DateTime.Parse("2022-10-10"), PaymentAmount = 200.00M},
                new Payment { PaymentID = 11102, CustomerID = 102, PaymentDate = DateTime.Parse("2022-10-10"), PaymentAmount = 200.00M },
                new Payment { PaymentID = 11103, CustomerID = 103, PaymentDate = DateTime.Parse("2022-10-17"), PaymentAmount = 300.00M },
                new Payment { PaymentID = 11104, CustomerID = 104, PaymentDate = DateTime.Parse("2022-10-17"), PaymentAmount = 300.00M },
                new Payment { PaymentID = 11105, CustomerID = 102, PaymentDate = DateTime.Parse("2022-10-12"), PaymentAmount = 300.00M },
                new Payment { PaymentID = 11106, CustomerID = 104, PaymentDate = DateTime.Parse("2022-10-12"), PaymentAmount = 200.00M },
                new Payment { PaymentID = 11107, CustomerID = 105, PaymentDate = DateTime.Parse("2022-10-20"), PaymentAmount = 400.00M },
                new Payment { PaymentID = 11108, CustomerID = 105, PaymentDate = DateTime.Parse("2022-10-20"), PaymentAmount = 300.00M },
                new Payment { PaymentID = 11109, CustomerID = 102, PaymentDate = DateTime.Parse("2022-10-12"), PaymentAmount = 200.00M },
                new Payment { PaymentID = 11110, CustomerID = 103, PaymentDate = DateTime.Parse("2022-10-17"), PaymentAmount = 500.00M }
            );
        }
    }
}

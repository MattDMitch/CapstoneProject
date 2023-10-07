using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JasperGreen.Models.SeedData
{
    internal class SeedProvidedService : IEntityTypeConfiguration<ProvidedService>
    {
        public void Configure(EntityTypeBuilder<ProvidedService> entity)
        {
            entity.HasData(
                new ProvidedService { ProvidedServiceID = 4001, CrewID = 701, CustomerID = 101, PropertyID = 2001, ServiceDate = DateTime.Parse("2022-10-10"), ServiceFee = 200.00M },
                new ProvidedService { ProvidedServiceID = 4002, CrewID = 701, CustomerID = 102, PropertyID = 2002, ServiceDate = DateTime.Parse("2022-10-10"), ServiceFee = 200.00M },
                new ProvidedService { ProvidedServiceID = 4003, CrewID = 702, CustomerID = 103, PropertyID = 2003, ServiceDate = DateTime.Parse("2022-10-10"), ServiceFee = 300.00M },
                new ProvidedService { ProvidedServiceID = 4004, CrewID = 702, CustomerID = 104, PropertyID = 2004, ServiceDate = DateTime.Parse("2022-10-10"), ServiceFee = 300.00M },
                new ProvidedService { ProvidedServiceID = 4005, CrewID = 703, CustomerID = 102, PropertyID = 2006, ServiceDate = DateTime.Parse("2022-10-12"), ServiceFee = 300.00M },
                new ProvidedService { ProvidedServiceID = 4006, CrewID = 703, CustomerID = 104, PropertyID = 2009, ServiceDate = DateTime.Parse("2022-10-12"), ServiceFee = 200.00M },
                new ProvidedService { ProvidedServiceID = 4007, CrewID = 704, CustomerID = 105, PropertyID = 2005, ServiceDate = DateTime.Parse("2022-10-12"), ServiceFee = 400.00M },
                new ProvidedService { ProvidedServiceID = 4008, CrewID = 704, CustomerID = 105, PropertyID = 20010, ServiceDate = DateTime.Parse("2022-10-12"), ServiceFee = 300.00M },
                new ProvidedService { ProvidedServiceID = 4009, CrewID = 705, CustomerID = 102, PropertyID = 2007, ServiceDate = DateTime.Parse("2022-10-13"), ServiceFee = 200.00M },
                new ProvidedService { ProvidedServiceID = 4010, CrewID = 705, CustomerID = 103, PropertyID = 2008, ServiceDate = DateTime.Parse("2022-10-13"), ServiceFee = 500.00M }
            );
        }
    }
}

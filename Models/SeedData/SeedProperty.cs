using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JasperGreen.Models.SeedData
{
    internal class SeedProperty : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> entity)
        {
            entity.HasData(
                new Property { PropertyID = 2001, CustomerID = 101, PropertyAddress = "616 Avengers St", PropertyCity = "College Station", PropertyState = "TX", PropertyZIP = "77840", ServiceFee = 200.00M},
                new Property { PropertyID = 2002, CustomerID = 102, PropertyAddress = "617 Avengers St", PropertyCity = "College Station", PropertyState = "TX", PropertyZIP = "77840", ServiceFee = 200.00M },
                new Property { PropertyID = 2003, CustomerID = 103, PropertyAddress = "120 Marvel Rd", PropertyCity = "College Station", PropertyState = "TX", PropertyZIP = "77843", ServiceFee = 300.00M },
                new Property { PropertyID = 2004, CustomerID = 104, PropertyAddress = "124 Marvel Rd", PropertyCity = "College Station", PropertyState = "TX", PropertyZIP = "77843", ServiceFee = 300.00M },
                new Property { PropertyID = 2005, CustomerID = 105, PropertyAddress = "111 Hero Ln", PropertyCity = "College Station", PropertyState = "TX", PropertyZIP = "77844", ServiceFee = 400.00M },
                new Property { PropertyID = 2006, CustomerID = 102, PropertyAddress = "200 Moon St", PropertyCity = "Bryan", PropertyState = "TX", PropertyZIP = "77801", ServiceFee = 300.00M },
                new Property { PropertyID = 2007, CustomerID = 102, PropertyAddress = "448 Knight St", PropertyCity = "College Station", PropertyState = "TX", PropertyZIP = "77842", ServiceFee = 200.00M },
                new Property { PropertyID = 2008, CustomerID = 103, PropertyAddress = "300 Arrow St", PropertyCity = "College Station", PropertyState = "TX", PropertyZIP = "77841", ServiceFee = 500.00M },
                new Property { PropertyID = 2009, CustomerID = 104, PropertyAddress = "380 Cap Dr", PropertyCity = "Bryan", PropertyState = "TX", PropertyZIP = "77806", ServiceFee = 200.00M },
                new Property { PropertyID = 20010, CustomerID = 105, PropertyAddress = "888 Armor St", PropertyCity = "Bryan", PropertyState = "TX", PropertyZIP = "77806", ServiceFee = 300.00M }
            );
        }
    }
}

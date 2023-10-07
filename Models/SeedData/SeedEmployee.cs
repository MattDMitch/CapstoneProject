using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JasperGreen.Models.SeedData
{
    internal class SeedEmployee : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.HasData(
                new Employee { EmployeeID = 501, EmployeeFirstName = "Tony", EmployeeLastName = "Stark", SSN = "111-00-2121", JobTitle = "Crew Foreman", HourlyRate = 30.00M, HireDate = DateTime.Parse("2016-01-01") },
                new Employee { EmployeeID = 502, EmployeeFirstName = "Steve", EmployeeLastName = "Rogers", SSN = "400-00-1200", JobTitle = "Crew Foreman", HourlyRate = 30.00M, HireDate = DateTime.Parse("2015-10-15") },
                new Employee { EmployeeID = 503, EmployeeFirstName = "Thor", EmployeeLastName = "Odinson", SSN = "110-11-8888", JobTitle = "Crew Foreman", HourlyRate = 30.00M, HireDate = DateTime.Parse("2016-04-16") },
                new Employee { EmployeeID = 504, EmployeeFirstName = "Bruce", EmployeeLastName = "Banner", SSN = "111-11-3333", JobTitle = "Crew Foreman", HourlyRate = 30.00M, HireDate = DateTime.Parse("2016-01-01") },
                new Employee { EmployeeID = 505, EmployeeFirstName = "Natasha", EmployeeLastName = "Romanoff", SSN = "400-00-4444", JobTitle = "Crew Foreman", HourlyRate = 30.00M, HireDate = DateTime.Parse("2016-05-15") },
                new Employee { EmployeeID = 506, EmployeeFirstName = "Clint", EmployeeLastName = "Barton", SSN = "111-00-7777", JobTitle = "Crew Member", HourlyRate = 18.00M, HireDate = DateTime.Parse("2016-10-15") },
                new Employee { EmployeeID = 507, EmployeeFirstName = "Nick", EmployeeLastName = "Fury", SSN = "110-22-9999", JobTitle = "Crew Member", HourlyRate = 18.00M, HireDate = DateTime.Parse("2017-01-01") },
                new Employee { EmployeeID = 508, EmployeeFirstName = "Sam", EmployeeLastName = "Wilson", SSN = "600-11-5555", JobTitle = "Crew Member", HourlyRate = 18.00M, HireDate = DateTime.Parse("2017-02-10") },
                new Employee { EmployeeID = 509, EmployeeFirstName = "Bucky", EmployeeLastName = "Barnes", SSN = "100-50-4200", JobTitle = "Crew Member", HourlyRate = 18.00M, HireDate = DateTime.Parse("11/1/2016") },
                new Employee { EmployeeID = 510, EmployeeFirstName = "Loki", EmployeeLastName = "Laufeyson", SSN = "250-50-2525", JobTitle = "Crew Member", HourlyRate = 18.00M, HireDate = DateTime.Parse("2017-05-01") },
                new Employee { EmployeeID = 511, EmployeeFirstName = "Wanda", EmployeeLastName = "Maximoff", SSN = "300-60-2222", JobTitle = "Crew Member", HourlyRate = 18.00M, HireDate = DateTime.Parse("2017-05-01") },
                new Employee { EmployeeID = 512, EmployeeFirstName = "Peter", EmployeeLastName = "Parker", SSN = "700-11-1111", JobTitle = "Crew Member", HourlyRate = 18.00M, HireDate = DateTime.Parse("2017-06-01") },
                new Employee { EmployeeID = 513, EmployeeFirstName = "Stephen", EmployeeLastName = "Strange", SSN = "300-11-0000", JobTitle = "Crew Member", HourlyRate = 18.00M, HireDate = DateTime.Parse("2017-06-01") },
                new Employee { EmployeeID = 514, EmployeeFirstName = "Scott", EmployeeLastName = "Lang", SSN = "111-00-1234", JobTitle = "Crew Member", HourlyRate = 18.00M, HireDate = DateTime.Parse("2017-06-15") },
                new Employee { EmployeeID = 515, EmployeeFirstName = "Matt", EmployeeLastName = "Murdock", SSN = "250-00-5678", JobTitle = "Crew Member", HourlyRate = 18.00M, HireDate = DateTime.Parse("2017-08-10") }
            );
        }
    }
}

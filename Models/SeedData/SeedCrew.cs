using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JasperGreen.Models.SeedData
{
    internal class SeedCrew : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> entity)
        {
            entity.HasData(
                new Crew { CrewID = 701, CrewForeman = 501, CrewMember1 = 506, CrewMember2 = 507 },
                new Crew { CrewID = 702, CrewForeman = 502, CrewMember1 = 508, CrewMember2 = 509 },
                new Crew { CrewID = 703, CrewForeman = 503, CrewMember1 = 510, CrewMember2 = 511 },
                new Crew { CrewID = 704, CrewForeman = 504, CrewMember1 = 512, CrewMember2 = 513 },
                new Crew { CrewID = 705, CrewForeman = 505, CrewMember1 = 514, CrewMember2 = 515 }
            );
        }
    }
}

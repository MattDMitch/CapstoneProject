using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JasperGreen.Models.SeedData
{
    internal class SeedState : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> entity)
        {
			entity.HasData(
				new State { StateID = "AL", Name = "Alabama" },
				new State { StateID = "AK", Name = "Alaska" },
				new State { StateID = "AZ", Name = "Arizona" },
				new State { StateID = "AR", Name = "Arkansas" },
				new State { StateID = "CA", Name = "California" },
				new State { StateID = "CO", Name = "Colorado" },
				new State { StateID = "CT", Name = "Connecticut" },
				new State { StateID = "DE", Name = "Delaware" },
				new State { StateID = "DC", Name = "District of Columbia" },
				new State { StateID = "FL", Name = "Florida" },
				new State { StateID = "GA", Name = "Georgia" },
				new State { StateID = "HI", Name = "Hawaii" },
				new State { StateID = "ID", Name = "Idaho" },
				new State { StateID = "IL", Name = "Illinois" },
				new State { StateID = "IN", Name = "Indiana" },
				new State { StateID = "IA", Name = "Iowa" },
				new State { StateID = "KS", Name = "Kansas" },
				new State { StateID = "KY", Name = "Kentucky" },
				new State { StateID = "LA", Name = "Louisiana" },
				new State { StateID = "ME", Name = "Maine" },
				new State { StateID = "MD", Name = "Maryland" },
				new State { StateID = "MA", Name = "Massachusetts" },
				new State { StateID = "MI", Name = "Michigan" },
				new State { StateID = "MN", Name = "Minnesota" },
				new State { StateID = "MS", Name = "Mississippi" },
				new State { StateID = "MO", Name = "Missouri" },
				new State { StateID = "MT", Name = "Montana" },
				new State { StateID = "NE", Name = "Nebraska" },
				new State { StateID = "NV", Name = "Nevada" },
				new State { StateID = "NH", Name = "New Hampshire" },
				new State { StateID = "NJ", Name = "New Jersey" },
				new State { StateID = "NM", Name = "New Mexico" },
				new State { StateID = "NY", Name = "New York" },
				new State { StateID = "NC", Name = "North Carolina" },
				new State { StateID = "ND", Name = "North Dakota" },
				new State { StateID = "OH", Name = "Ohio" },
				new State { StateID = "OK", Name = "Oklahoma" },
				new State { StateID = "OR", Name = "Oregon" },
				new State { StateID = "PA", Name = "Pennsylvania" },
				new State { StateID = "RI", Name = "Rhode Island" },
				new State { StateID = "SC", Name = "South Carolina" },
				new State { StateID = "SD", Name = "South Dakota" },
				new State { StateID = "TN", Name = "Tennessee" },
				new State { StateID = "TX", Name = "Texas" },
				new State { StateID = "UT", Name = "Utah" },
				new State { StateID = "VT", Name = "Vermont" },
				new State { StateID = "VA", Name = "Virginia" },
				new State { StateID = "WA", Name = "Washington" },
				new State { StateID = "WV", Name = "West Virginia" },
				new State { StateID = "WI", Name = "Wisconsin" },
				new State { StateID = "WY", Name = "Wyoming" }
			);
        }
    }
}

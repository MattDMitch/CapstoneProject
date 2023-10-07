using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace JasperGreen.Models
{
	public class Crew
	{
		public int CrewID { get; set; } //primary key

		[Required(ErrorMessage = "Please select a crew foreman.")]
		[ForeignKey("EmployeeID")]
		[InverseProperty("Crews")]
		public int CrewForeman { get; set; } // foreign key property for Crew foreman
		public Employee EmpForeman { get; set; } // navigation property

		[Required(ErrorMessage = "Please select a crew member 1.")]
		[ForeignKey("EmployeeID")]
		public int CrewMember1 { get; set; } // foreign key property for crew member 1
		public Employee EmpMember1 { get; set; } // navigation property

		[Required(ErrorMessage = "Please select a crew member 2.")]
		[ForeignKey("EmployeeID")]
		public int CrewMember2 { get; set; } // foreign key property for crew member 2
		public Employee EmpMember2 { get; set; } // navigation property

		// navigation property to linking entity
		public ICollection<ProvidedService> ProvidedServices { get; set; }

	}
}
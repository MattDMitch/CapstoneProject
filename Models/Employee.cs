using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace JasperGreen.Models
{
	public class Employee
	{
		public int EmployeeID { get; set; } //primary key

		[Required(ErrorMessage = "Please enter a first name.")]
		public string EmployeeFirstName { get; set; }

		[Required(ErrorMessage = "Please enter a last name.")]
		public string EmployeeLastName { get; set; }

		[Required(ErrorMessage = "Please enter a SSN.")]
		public string SSN { get; set; }

		[Required(ErrorMessage = "Please enter a job title.")]
		public string JobTitle { get; set; }

		[Required(ErrorMessage = "Please enter a hourly rate.")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal HourlyRate { get; set; }

		[Required(ErrorMessage = "Please enter a hire date.")]
		public DateTime HireDate { get; set; }

		// navigation properties to linking entity
		public ICollection<Crew> Crews { get; set; }
		public ICollection<Crew> Member1 { get; set; }
		public ICollection<Crew> Member2 { get; set; }

		public string EmployeeFullName => EmployeeFirstName + " " + EmployeeLastName;   // read-only property
	}
}
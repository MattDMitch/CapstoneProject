using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JasperGreen.Models
{
	public class ProvidedService
	{
		[Key]
		public int ProvidedServiceID { get; set; } //primary key

		[Required(ErrorMessage = "Please enter a service date.")]
		public DateTime ServiceDate{ get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Please enter a service fee.")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal ServiceFee { get; set; }

		[Required(ErrorMessage = "Please select a crew.")]
		public int CrewID { get; set; } // foreign key property for Crew
		public Crew Crew { get; set; } // navigation property

		[Required(ErrorMessage = "Please select a customer.")]
		public int CustomerID { get; set; }     // foreign key property for Customer
		public Customer Customer { get; set; }  // navigation property

		[Required(ErrorMessage = "Please select a property.")]
		public int PropertyID { get; set; }     // foreign key property for Property
		public Property Property { get; set; }  // navigation property
	}
}
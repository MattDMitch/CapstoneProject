using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace JasperGreen.Models
{
	public class Property
	{
		public int PropertyID { get; set; } // primary key

		[Required(ErrorMessage = "Please select a customer.")]
		public int CustomerID { get; set; }     // foreign key property for Customer
		public Customer Customer { get; set; }  // navigation property

		[Required(ErrorMessage = "Please enter a property address.")]
		public string PropertyAddress { get; set; }

		[Required(ErrorMessage = "Please enter a property city.")]
		public string PropertyCity { get; set; }

		[Required(ErrorMessage = "Please enter a property state.")]
		public string PropertyState { get; set; }

		[Required(ErrorMessage = "Please enter a property ZIP code.")]
		[RegularExpression(@"\d{5}(-\d{4})?$", ErrorMessage = "ZIP code must be in 99999 or 99999-9999 format.")]
		public string PropertyZIP { get; set; }

		[Required(ErrorMessage = "Please enter a service fee.")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal ServiceFee { get; set; }

		// navigation property to linking entity
		public ICollection<ProvidedService> ProvidedServices { get; set; }
	}
}
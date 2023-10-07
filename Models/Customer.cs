using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace JasperGreen.Models
{
	public class Customer
	{
		public int CustomerID { get; set; } //primary key

		[Required(ErrorMessage = "Please enter a name.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please enter a billing address.")]
		public string BillingAddress { get; set; }

		[Required(ErrorMessage = "Please enter a billing city.")]
		public string BillingCity { get; set; }

		[Required(ErrorMessage = "Please select a billing state.")]
		public string StateID { get; set; }
		public State State { get; set; }

		[Required(ErrorMessage = "Please enter a billing ZIP code.")]
		[RegularExpression(@"\d{5}(-\d{4})?$", ErrorMessage = "ZIP code must be in 99999 or 99999-9999 format.")]
		public string BillingZIP { get; set; }

		[Required(ErrorMessage = "Please enter a phone number.")]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number must be in 999-999-9999 format")]
		public string PhoneNumber { get; set; }

		// navigation properties to linking entity
		public ICollection<Property> Properties { get; set; }
		public ICollection<Payment> Payments { get; set; }
		public ICollection<ProvidedService> ProvidedServices { get; set; }
	}
}
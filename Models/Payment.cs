using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JasperGreen.Models
{
	public class Payment
	{
		public int PaymentID { get; set; } //primary key

		[Required(ErrorMessage = "Please select a customer.")]
		public int CustomerID { get; set; }     // foreign key property for Customer
		public Customer Customer { get; set; }  // navigation property

		[Required(ErrorMessage = "Please enter a payment date.")]
		public DateTime PaymentDate { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Please enter a payment amount.")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal PaymentAmount { get; set; }

		// navigation property to linking entity
		public ICollection<ProvidedService> ProvidedServices { get; set; }
	}
}
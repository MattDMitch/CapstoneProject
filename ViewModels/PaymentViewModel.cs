using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ViewModel for building the customer list and sharing it between the payment controller and view.

namespace JasperGreen.Models
{
    public class PaymentViewModel
    {
        public Payment Payment { get; set; }
        public string Action { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
    }
}

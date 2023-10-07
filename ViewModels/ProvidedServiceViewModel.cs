using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ViewModel for building the customer, property, payment, and crew list and sharing it between the provided service controller and view.

namespace JasperGreen.Models
{
    public class ProvidedServiceViewModel
    {
        public ProvidedService ProvidedService { get; set; }
        public string Action { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Property> Properties { get; set; }
        //public IEnumerable<Payment> Payments { get; set; }
        public IEnumerable<Crew> Crews { get; set; }
        public IEnumerable<ProvidedService> ProvidedServices { get; set; }
    }
}

using System.Collections.Generic;

//ViewModel for building the customer list and sharing it between the property controller and view.

namespace JasperGreen.Models
{
    public class PropertyViewModel
    {
        public Property Property { get; set; }
        public string Action { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Property> Properties { get; set; }
    }
}

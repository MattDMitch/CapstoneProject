using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ViewModel that builds the employee list and shares it between the controller and view.

namespace JasperGreen.Models
{
    public class CrewViewModel
    {
        public Crew Crew { get; set; }
        public string Action { get; set; }

        public IEnumerable<Crew> Crews { get; set; }
        public IEnumerable<Employee> EmpForeman { get; set; }
        public IEnumerable<Employee> EmpMember1 { get; set; }
        public IEnumerable<Employee> EmpMember2 { get; set; }
    }
}

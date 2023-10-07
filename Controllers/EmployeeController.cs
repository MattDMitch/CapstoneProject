//AUTHOR:       Colleen Anderson and Matthew Mitchell
//COURSE:       ISTM 415-501
//CONTROLLER:   EmployeeController.cs
//PURPOSE:      Lets an admin user view, edit, and delete existing
//              employees as well as add new employees.
//INITIALIZE:   Jasper Green database
//PROCESS:      List,Add/Edit, and Save() actions
//OUTPUT:       Displays the Home page, About us, and contact page.
//HONOR CODE:   “On my honor, as an Aggie, I have neither given
//              nor received unauthorized aid on this academic work.



using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JasperGreen.Models;

namespace JasperGreen.Controllers
{
    public class EmployeeController : Controller
    {
        private JasperGreenContext context { get; set; }

        public EmployeeController(JasperGreenContext ctx)
        {
            context = ctx;
        }

        //Displays a list of all employees
        [Route("[controller]s")]
        public IActionResult List()
        {
            List<Employee> employees = context.Employees.OrderBy(c => c.EmployeeFirstName).ToList();
            return View(employees);
        }

        //Display the Add/Edit Employee page with blank fields.
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            return View("AddEdit", new Employee());
        }

        //Displays the Add/Edit Employee page with the data for the selected employee
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var employee = context.Employees.Find(id);
            return View("AddEdit", employee);
        }

        //Adds new employee, updates existing ones, saves changes
        [HttpPost]
        public IActionResult Save(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.EmployeeID == 0)
                {
                    context.Employees.Add(employee);
                }
                else
                {
                    context.Employees.Update(employee);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                if (employee.EmployeeID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";

                }
                return View("AddEdit", employee);
            }
        }

        //Displays a Delete Employee page to confirm the deletion
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = context.Employees.Find(id);
            return View(employee);
        }

        //Deletes the employee and redirects to the Employee list page
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            var e = context.Employees.Find(employee.EmployeeID);

            //captures the database update issue when trying to delete an entity with dependents
            try
            {
                context.Employees.Remove(e);
                context.SaveChanges();
            }
            catch
            {
                string message = e.EmployeeFullName + " has one or more relationships with crew and cannot be deleted.";
                TempData["message"] = message;
            }
            return RedirectToAction("List");
        }
    }
}


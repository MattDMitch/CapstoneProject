//AUTHOR:       Colleen Anderson and Matthew Mitchell
//COURSE:       ISTM 415-501
//CONTROLLER:   CustomerController.cs
//PURPOSE:      Lets an admin user view, edit, and delete existing
//              customers as well as add new customers.
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
    public class CustomerController : Controller
    {
        private JasperGreenContext context { get; set; }

        public CustomerController(JasperGreenContext ctx)
        {
            context = ctx;
        }

        //Displays a list of all customers
        [Route("[controller]s")]
        public IActionResult List()
        {
            List<Customer> customers = context.Customers.OrderBy(c => c.Name).ToList();
            return View(customers);
        }

        //Display the Add/Edit Customer page with blank fields.
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            ViewBag.States = context.States.ToList();

            return View("AddEdit", new Customer());
        }

        //Displays the Add/Edit Customer page with the data for the selected customer
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            ViewBag.States = context.States.ToList();

            var customer = context.Customers.Find(id);
            return View("AddEdit", customer);
        }

        //Adds new customer, updates existing ones, saves changes
        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            if (customer.StateID == "")
            {
                ModelState.AddModelError(nameof(Customer.StateID), "Please select a billing state.");
            }

            string message;
            if (ModelState.IsValid)
            {
                if (customer.CustomerID == 0)
                {
                    context.Customers.Add(customer);
                    message = customer.Name + " was added.";
                }
                else
                {
                    context.Customers.Update(customer);
                    message = customer.Name + " was updated.";
                }
                context.SaveChanges();
                TempData["message"] = message;
                return RedirectToAction("List");
            }
            else
            {
                if (customer.CustomerID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";

                }
                // added ViewBag.States code to address issue with saving empty state
                ViewBag.States = context.States.ToList();
                return View("AddEdit", customer);
            }
        }

        //Displays a Delete Customer page to confirm the deletion
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        //Deletes the customer and redirects to the Customer list page
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            var c = context.Customers.Find(customer.CustomerID);

            //captures the database update issue when trying to delete an entity with dependents
            try
            {
                context.Customers.Remove(c);
                context.SaveChanges();
            }
            catch
            {
                string message = c.Name + " has one or more relationships with property, payment, or provided service and cannot be deleted.";
                TempData["message"] = message;
            }
            return RedirectToAction("List");
        }
    }
}

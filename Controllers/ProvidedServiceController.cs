//AUTHOR:       Colleen Anderson and Matthew Mitchell
//COURSE:       ISTM 415-501
//CONTROLLER:   ProvidedServiceController.cs
//PURPOSE:      Controller to manage Provided Service events
//INITIALIZE:   Jasper Green database
//PROCESS:      List, Add/Edit, Save(), and Delete() actions
//OUTPUT:       Displays the Home page, About us, and contact page.
//HONOR CODE:   “On my honor, as an Aggie, I have neither given
//              nor received unauthorized aid on this academic work.


using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JasperGreen.Models;
using Microsoft.AspNetCore.Http;

namespace JasperGreen.Controllers
{
    public class ProvidedServiceController : Controller
    {
        private JasperGreenContext context { get; set; }

        public ProvidedServiceController(JasperGreenContext ctx)
        {
            context = ctx;
        }

        //Displays a list of all services
        [Route("[controller]")]
        public IActionResult List()
        {
            ProvidedServiceViewModel model = new ProvidedServiceViewModel();

            IQueryable<ProvidedService> query = context.ProvidedServices
                .Include(i => i.Customer)
                .Include(i => i.Property)
                .Include(i => i.Crew);


            List<ProvidedService> services = query.ToList();
            model.ProvidedServices = services;

            return View(model);
        }

        //helper method
        private ProvidedServiceViewModel GetViewModel()
        {
            ProvidedServiceViewModel model = new ProvidedServiceViewModel
            {
                Customers = context.Customers
                    .OrderBy(c => c.Name)
                    .ToList(),

                Properties = context.Properties
                    .OrderBy(c => c.PropertyAddress)
                    .ToList(),

                Crews = context.Crews
                    .OrderBy(c => c.CrewID)
                    .ToList(),
            };

            return model;
        }

        //Creates the drop-down list for customer filter button
        [HttpGet]
        public IActionResult GetCustomer()
        {
            int? id = HttpContext.Session.GetInt32("CustomerID");
            Customer customer;
            if (id == null || id == 0)
            {
                customer = new Customer();
            }
            else
            {
                customer = context.Customers.Find(id);
            }

            ViewBag.Customers = context.Customers.ToList();
            return View(customer);
        }

        //Displays the drop list for customer filter button
        [HttpPost]
        public IActionResult GetCustomer(Customer customer)
        {
            HttpContext.Session.SetInt32("CustomerID", customer.CustomerID);

            List<ProvidedService> services = context.ProvidedServices
                .Include(i => i.Customer)
                .OrderBy(i => i.Customer)
                .Include(i => i.Property)
                .Include(i => i.Crew)
                .Where(i => i.CustomerID == customer.CustomerID)
                .ToList();

            ProvidedServiceViewModel model = new ProvidedServiceViewModel();
            model.ProvidedServices = services;
            return View("List", model);
        }

        //Creates the drop-down list for crew filter button
        [HttpGet]
        public IActionResult GetCrew()
        {
            int? id = HttpContext.Session.GetInt32("CrewID");
            Crew crew;
            if (id == null || id == 0)
            {
                crew = new Crew();
            }
            else
            {
                crew = context.Crews.Find(id);
            }

            ViewBag.Crews = context.Crews.ToList();
            return View(crew);
        }

        //Displays the drop list for crew filter button
        [HttpPost]
        public IActionResult GetCrew(Crew crew)
        {
            HttpContext.Session.SetInt32("CrewID", crew.CrewID);

            List<ProvidedService> services = context.ProvidedServices
                .Include(i => i.Customer)
                .OrderBy(i => i.Customer)
                .Include(i => i.Property)
                .Include(i => i.Crew)
                .Where(i => i.CrewID == crew.CrewID)
                .ToList();
            ProvidedServiceViewModel model = new ProvidedServiceViewModel();
            model.ProvidedServices = services;
            return View("List", model);
        }

        //Creates the drop-down list for property filter button
        [HttpGet]
        public IActionResult GetProperty()
        {
            int? id = HttpContext.Session.GetInt32("PropertyID");
            Property property;
            if (id == null || id == 0)
            {
                property = new Property();
            }
            else
            {
                property = context.Properties.Find(id);
            }

            ViewBag.Properties = context.Properties.ToList();
            return View(property);
        }

        //Displays the drop list for property filter button
        [HttpPost]
        public IActionResult GetProperty(Property property)
        {
            HttpContext.Session.SetInt32("PropertyID", property.PropertyID);

            List<ProvidedService> services = context.ProvidedServices
                .Include(i => i.Customer)
                .OrderBy(i => i.Customer)
                .Include(i => i.Property)
                .Include(i => i.Crew)
                .Where(i => i.PropertyID == property.PropertyID)
                .ToList();

            ProvidedServiceViewModel model = new ProvidedServiceViewModel();
            model.ProvidedServices = services;
            return View("List", model);
        }

        //Display the Add/Edit Provided Service page with blank fields.
        [HttpGet]
        public IActionResult Add()
        {
            ProvidedServiceViewModel model = GetViewModel();
            model.ProvidedService = new ProvidedService();
            model.Action = "Add";

            return View("AddEdit", model);
        }

        //Displays the Add/Edit Provided Service page with the data for the selected provided service
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProvidedServiceViewModel model = GetViewModel();
            var service = context.ProvidedServices.Find(id);
            model.ProvidedService = service;
            model.Action = "Edit";

            return View("AddEdit", model);
        }

        //Adds new service, updates existing ones, saves changes
        [HttpPost]
        public IActionResult Save(ProvidedService providedService)
        {

            //checks if provided service fee is greater than or equal to the service fee stored with the associated property
            string message = Check.ServiceFeeCheck(context, providedService.PropertyID, providedService.ServiceFee);
            if (!String.IsNullOrEmpty(message))
            {
                ModelState.AddModelError(nameof(providedService.ServiceFee), message);
                TempData["message"] = message;
            }

            ProvidedServiceViewModel model = GetViewModel();
            if (providedService.ProvidedServiceID == 0)
            {
                model.Action = "Add";
            }
            else
            {
                model.Action = "Edit";
            }

            if (ModelState.IsValid)
            {
                if (model.Action == "Add")
                {
                    context.ProvidedServices.Add(providedService);
                }
                else
                {
                    context.ProvidedServices.Update(providedService);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                if (providedService.ProvidedServiceID == 0)
                {
                    model.Action = "Add";
                }
                else
                {
                    model.Action = "Edit";
                }
                model.ProvidedService = providedService;
                return View("AddEdit", model);
            }
        }

        //Displays a Delete Provided Service page to confirm the deletion
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var service = context.ProvidedServices.Find(id);
            return View(service);
        }

        //Deletes the service and redirects to the Provided Service list page
        [HttpPost]
        public IActionResult Delete(ProvidedService service)
        {
            context.ProvidedServices.Remove(service);
            context.SaveChanges();
            return RedirectToAction("List");
        }

    }
}

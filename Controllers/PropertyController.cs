//AUTHOR:       Colleen Anderson and Matthew Mitchell
//COURSE:       ISTM 415-501
//CONTROLLER:   PropertyController.cs
//PURPOSE:      Lets an admin user view, edit, and delete existing
//              properties as well as add new properties.
//INITIALIZE:   Jasper Green database
//PROCESS:      List,Add/Edit, and Save() actions
//OUTPUT:       Displays the Home page, About us, and contact page.
//HONOR CODE:   “On my honor, as an Aggie, I have neither given
//              nor received unauthorized aid on this academic work.


using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JasperGreen.Models;

namespace JasperGreen.Controllers
{
    public class PropertyController : Controller
    {
        private JasperGreenContext context { get; set; }

        public PropertyController(JasperGreenContext ctx)
        {
            context = ctx;
        }

        //Displays a list of all properties
        [Route("[controller]")]
        public IActionResult List()
        {
            PropertyViewModel model = new PropertyViewModel();

            IQueryable<Property> query = context.Properties
                .Include(i => i.Customer);


            List<Property> properties = query.ToList();
            model.Properties = properties;

            return View(model);
        }

        //helper method
        private PropertyViewModel GetViewModel()
        {
            PropertyViewModel model = new PropertyViewModel
            {
                Customers = context.Customers
                    .OrderBy(c => c.Name)
                    .ToList(),
            };

            return model;
        }

        //Display the Add/Edit Property page with blank fields.
        [HttpGet]
        public IActionResult Add()
        {
            PropertyViewModel model = GetViewModel();
            model.Property = new Property();
            model.Action = "Add";

            return View("AddEdit", model);
        }

        //Displays the Add/Edit Property page with the data for the selected property
        [HttpGet]
        public IActionResult Edit(int id)
        {
            PropertyViewModel model = GetViewModel();
            var property = context.Properties.Find(id);
            model.Property = property;
            model.Action = "Edit";

            return View("AddEdit", model);
        }

        //Adds new property, updates existing ones, saves changes
        [HttpPost]
        public IActionResult Save(Property property)
        {
            PropertyViewModel model = GetViewModel();
            if (property.PropertyID == 0)
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
                    context.Properties.Add(property);
                }
                else
                {
                    context.Properties.Update(property);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                model.Property = property;
                return View("AddEdit", model);
            }
        }

        //Displays a Delete Property page to confirm the deletion
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var property = context.Properties.Find(id);
            return View(property);
        }

        //Deletes the property and redirects to the Property list page
        [HttpPost]
        public IActionResult Delete(Property property)
        {
            var p = context.Properties.Find(property.PropertyID);

            //captures the database update issue when trying to delete an entity with dependents
            try
            {
                context.Properties.Remove(p);
                context.SaveChanges();
            }
            catch
            {
                string message = "Property " + p.PropertyAddress + " has one or more relationships with customer or provided service and cannot be deleted.";
                TempData["message"] = message;
            }
            return RedirectToAction("List");
        }

    }
}

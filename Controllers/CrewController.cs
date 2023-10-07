//AUTHOR:       Colleen Anderson and Matthew Mitchell
//COURSE:       ISTM 415-501
//CONTROLLER:   CrewController.cs
//PURPOSE:      Lets an admin user view, edit, and delete existing
//              crews as well as add new crews.
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
    public class CrewController : Controller
    {
        private JasperGreenContext context { get; set; }

        public CrewController(JasperGreenContext ctx)
        {
            context = ctx;
        }

        //Displays a list of all crews
        [Route("[controller]s")]
        public IActionResult List()
        {
            CrewViewModel model = new CrewViewModel();

            //IQueryable<Crew> query 
            List<Crew> crews = context.Crews
                .Include(i => i.EmpForeman)
                .Include(i => i.EmpMember1)
                .Include(i => i.EmpMember2).ToList();


            //List<Crew> crews = query.ToList();
            model.Crews = crews;

            return View(model);
        }

        //helper method
        private CrewViewModel GetViewModel()
        {
            CrewViewModel model = new CrewViewModel
            {
                EmpForeman = context.Employees
                    .OrderBy(c => c.EmployeeFirstName)
                    .ToList(),

                EmpMember1 = context.Employees
                    .OrderBy(c => c.EmployeeFirstName)
                    .ToList(),

                EmpMember2 = context.Employees
                    .OrderBy(c => c.EmployeeFirstName)
                    .ToList(),
            };

            return model;
        }

        //Display the Add/Edit Crew page with blank fields.
        [HttpGet]
        public IActionResult Add()
        {
            CrewViewModel model = GetViewModel();
            model.Crew = new Crew();
            model.Action = "Add";

            ViewBag.Crews = context.Employees.ToList();

            return View("AddEdit", model);
        }

        //Displays the Add/Edit Crew page with the data for the selected crew
        [HttpGet]
        public IActionResult Edit(int id)
        {
            CrewViewModel model = GetViewModel();
            var crew = context.Crews.Find(id);
            model.Crew = crew;
            model.Action = "Edit";
            ViewBag.Crews = context.Employees.ToList();

            return View("AddEdit", model);
        }

        //Adds new crew, updates existing ones, saves changes
        [HttpPost]
        public IActionResult Save(Crew crew)
        {
            //check for unique crew values
            string message;
            message = Check.UniqueCrew(context, crew.CrewForeman, crew.CrewMember1, crew.CrewMember2);
            if (!String.IsNullOrEmpty(message))
            {
                ModelState.AddModelError(nameof(Crew.CrewForeman), message);
                TempData["message"] = message;
            }

            CrewViewModel model = GetViewModel();
            if (crew.CrewID == 0)
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
                    context.Crews.Add(crew);
                }
                else
                {
                    context.Crews.Update(crew);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Crews = context.Employees.ToList();
                model.Crew = crew;
                return View("AddEdit", model);
            }
        }

        //Displays a Delete Crew page to confirm the deletion
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var crew = context.Crews.Find(id);
            return View(crew);
        }

        //Deletes the crew and redirects to the Crew list page
        [HttpPost]
        public IActionResult Delete(Crew crew)
        {
            var c = context.Crews.Find(crew.CrewID);

            //captures the database update issue when trying to delete an entity with dependents
            try
            {
                context.Crews.Remove(c);
                context.SaveChanges();
            }
            catch
            {
                string message = "Crew " + c.CrewID + " has one or more relationships with employee or provided service and cannot be deleted.";
                TempData["message"] = message;
            }
            return RedirectToAction("List");
        }

    }
}

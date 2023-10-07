//AUTHOR:       Colleen Anderson and Matthew Mitchell
//COURSE:       ISTM 415-501
//CONTROLLER:   PaymentController.cs
//PURPOSE:      Controller to manage Payment events
//INITIALIZE:   Jasper Green database
//PROCESS:      List, Add/Edit, Delete() and Save() actions
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
    public class PaymentController : Controller
    {
        private JasperGreenContext context { get; set; }

        public PaymentController(JasperGreenContext ctx)
        {
            context = ctx;
        }

        //Displays a list of all payments
        [Route("[controller]")]
        public IActionResult List()
        {
            PaymentViewModel model = new PaymentViewModel();

            IQueryable<Payment> query = context.Payments
                .Include(i => i.Customer);


            List<Payment> payments = query.ToList();
            model.Payments = payments;

            return View(model);
        }

        //helper method
        private PaymentViewModel GetViewModel()
        {
            PaymentViewModel model = new PaymentViewModel
            {
                Customers = context.Customers
                    .OrderBy(c => c.Name)
                    .ToList(),
            };

            return model;
        }

        //Display the Add/Edit Payment page with blank fields.
        [HttpGet]
        public IActionResult Add()
        {
            PaymentViewModel model = GetViewModel();
            model.Payment = new Payment();
            model.Action = "Add";

            return View("AddEdit", model);
        }

        //Displays the Add/Edit Payment page with the data for the selected Payment
        [HttpGet]
        public IActionResult Edit(int id)
        {
            PaymentViewModel model = GetViewModel();
            var payment = context.Payments.Find(id);
            model.Payment = payment;
            model.Action = "Edit";

            return View("AddEdit", model);
        }

        //Adds new Payment, updates existing ones, saves changes
        [HttpPost]
        public IActionResult Save(Payment payment)
        {
            PaymentViewModel model = GetViewModel();
            if (payment.PaymentID == 0)
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
                    context.Payments.Add(payment);
                }
                else
                {
                    context.Payments.Update(payment);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                model.Payment = payment;
                return View("AddEdit", model);
            }
        }

        //Displays a Delete Payment page to confirm the deletion
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var payment = context.Payments.Find(id);
            return View(payment);
        }

        //Deletes the Payment and redirects to the Payment list page
        [HttpPost]
        public IActionResult Delete(Payment payment)
        {
            var p = context.Payments.Find(payment.PaymentID);

            //captures the database update issue when trying to delete an entity with dependents
            try
            {
                context.Payments.Remove(p);
                context.SaveChanges();
            }
            catch
            {
                string message = "Payment " + p.PaymentID + " has one or more relationships with customer or provided service and cannot be deleted.";
                TempData["message"] = message;
            }
            return RedirectToAction("List");
        }

    }
}

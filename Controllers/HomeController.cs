using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JasperGreen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

//AUTHOR:       Colleen Anderson and Matthew Mitchell
//COURSE:       ISTM 415-501
//CONTROLLER:   HomeController.cs
//PURPOSE:      Lets an admin user view home, about, and contact page
//INITIALIZE:   Jasper Green database
//PROCESS:      Index(), About(), ContactUs(), and Save() actions
//OUTPUT:       Displays the Home page, About us, and contact page.
//HONOR CODE:   “On my honor, as an Aggie, I have neither given
//              nor received unauthorized aid on this academic work.

namespace JasperGreen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult About()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Save()
        {
            return View();
        }

    }
}

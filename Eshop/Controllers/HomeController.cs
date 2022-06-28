using Eshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Controllers
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
            //var student = new Student {FirstName = "saeed",LastName = "rahgooy" };
            //List<Kwp> lst = new List<Kwp>();
            //var kwp = new Kwp {Name = "FirstName",Value = "saeed" };
            //lst.Add(kwp);
            //kwp = new Kwp {Name = "LastName",Value = "rahgooy" };
            //string str = "FirstName = saeed&LastName = rahgooy";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

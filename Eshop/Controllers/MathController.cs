using Eshop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Controllers
{
    public class MathController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeAdd(Numbers n)
        {
            ViewBag.Sum = n.FirstNumber + n.SecondNumber;
            return View();
        }
        public IActionResult Sub()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeSub(Numbers n)
        {
            n.Result = n.FirstNumber - n.SecondNumber;
            return View(n);
        }

        public IActionResult Multi()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Multi(Numbers n)
        {
            n.Result = n.FirstNumber * n.SecondNumber;
            return View(n);
        }
        public IActionResult Test()
        {
            return View();
        }
    }
}

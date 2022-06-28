using BusSeviceContract.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryBusiness CatBus;

        public CategoryController(ICategoryBusiness CatBus)
        {
            this.CatBus = CatBus;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

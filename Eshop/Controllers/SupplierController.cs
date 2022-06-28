using BusinessServiceContract.Services;
using DomainModel.DTOS.Supplier;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierBusiness supBus;
        public SupplierController(ISupplierBusiness supBus)
        {
            this.supBus = supBus;
        }
        public IActionResult Index(SupplierSearchModel sm)
        {
            return View(sm);
        }
        public IActionResult List(SupplierSearchModel sm)
        {
            return ViewComponent("SupplierSearchList",sm);
        }
        public IActionResult AddNew()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult AddNew(SupplierAddEditModel sup)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var op = supBus.AddNew(sup);
        //        if (op.Success)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            TempData["errorMessage"] = op.Message;
        //            return View(sup);
        //        }
        //    }
        //    else
        //    {
        //        TempData["errorMessage"] = "Some Message";
        //        return View(sup);
        //    }

        //}
        [HttpPost]
        public JsonResult AddNew(SupplierAddEditModel sup)
        {
            var op = supBus.AddNew(sup);
            return Json(op);
        }
        [HttpPost]
        public IActionResult Delete(int supplierId)
        {
            var op = supBus.Delete(supplierId);
            return Json(op);
        }
        public IActionResult Update(int SupplierID)
        {
            var supplier = supBus.Get(SupplierID);
            return View(supplier);
        }
        [HttpPost]
        public JsonResult Update(SupplierAddEditModel sup)
        {
            var op = supBus.Update(sup);
            return Json(op);
        }
    }
}

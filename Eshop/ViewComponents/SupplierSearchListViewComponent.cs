using BusinessServiceContract.Services;
using DomainModel.DTOS.Supplier;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.ViewComponents
{
    [ViewComponent(Name ="SupplierSearchList")]
    public class SupplierSearchListViewComponent : ViewComponent
    {
        private readonly ISupplierBusiness supBus;
        public SupplierSearchListViewComponent(ISupplierBusiness supBus)
        {
            this.supBus = supBus;
        }
        public IViewComponentResult Invoke(SupplierSearchModel sm)
        {
            int rc = 0;

            if (sm == null || sm.PageSize ==0) 
            {
              sm = new SupplierSearchModel { PageSize = 10 } ;
            }
            var result = supBus.Search(sm,out rc).MainResult;
            return View(result);
        }
    }
}

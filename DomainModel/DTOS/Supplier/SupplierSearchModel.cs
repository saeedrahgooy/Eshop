using DomainModel.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTOS.Supplier
{
    public class SupplierSearchModel : PageModel
    {
        public string SupplierName { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
    }
}

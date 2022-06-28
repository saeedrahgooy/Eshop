using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTOS.Supplier
{
    public class SupplierComplexResult : IComplexObjectResult<List<SupplierListItem>, List<string>>
    {
        private List<SupplierListItem> mainResult;
        public List<SupplierListItem> MainResult 
        { 
            get { return this.mainResult; }
            set { this.mainResult = value; }
        }
        private List<string> errors;
        public List<string> Errors 
        {
            get { return this.errors; }
            set { this.errors = value; }
        }
    }
}

using DomainModel;
using DomainModel.DTOS.Supplier;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServiceContract.Services
{
    public interface ISupplierBusiness
    {
        OperationResult Delete(int Id);
        OperationResult Update(SupplierAddEditModel current);
        OperationResult AddNew(SupplierAddEditModel current);
        SupplierAddEditModel Get(int Id);
        List<Supplier> GetAll();
        SupplierComplexResult Search(SupplierSearchModel sm, out int RecordCount);
    }
}

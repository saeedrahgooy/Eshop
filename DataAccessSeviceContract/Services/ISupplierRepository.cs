using DataAccessSeviceContract.Services.Base;
using DomainModel;
using DomainModel.DTOS.Supplier;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessSeviceContract.Services
{
    public interface ISupplierRepository : IBaseRepositorySearchable<Supplier,int, SupplierSearchModel,SupplierComplexResult>
    {
        bool HasRelatedProduct(int Id);
        bool HasDuplicateName(string Name);
        bool CheckSupplierNameExistForOtherId(int Id, string SupplierName);
    }
}

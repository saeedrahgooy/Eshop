using BusinessServiceContract.Services;
using DataAccessSeviceContract.Services;
using DomainModel;
using DomainModel.DTOS.Supplier;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class SupplierBusiness : ISupplierBusiness
    {
        private SupplierAddEditModel ToAddEditModel(Supplier sup)
        {
            return new SupplierAddEditModel
            {
                SupplierName = sup.SupplierName,
                Mobile=sup.Mobile,
                Address = sup.Address,
                SupplierID = sup.SupplierID,
                Tel = sup.Tel
            };
        }
        private Supplier ToSupplierModel(SupplierAddEditModel sup)
        {
            return new Supplier
            {
                SupplierName = sup.SupplierName,
                Mobile = sup.Mobile,
                Address = sup.Address,
                SupplierID = sup.SupplierID,
                Tel = sup.Tel,                
            };
        }
        private readonly ISupplierRepository _repo;
        public SupplierBusiness(ISupplierRepository repo)
        {
            _repo = repo;
        }
        public OperationResult AddNew(SupplierAddEditModel current)
        {
            OperationResult op = new OperationResult("Add Supplier");
            if (_repo.HasDuplicateName(current.SupplierName))
            {
                return op.Failed("this supplier name already exist",null);
            }
            var sup = ToSupplierModel(current);
            return _repo.AddNew(sup);
        }

        public OperationResult Delete(int Id)
        {
            
            if (_repo.HasRelatedProduct(Id))
            {
                return new OperationResult("Delete Supplier").Failed("this supplier has related product", Id);
            }
            return _repo.Delete(Id);
        }
        public OperationResult Update(SupplierAddEditModel current)
        {
            if (_repo.CheckSupplierNameExistForOtherId(current.SupplierID, current.SupplierName))
            {
                return new OperationResult("Update Supplier").Failed("Supplier already Exist", current.SupplierID);
            }
            var sup = ToSupplierModel(current);
            return _repo.Update(sup);
        }

        public SupplierAddEditModel Get(int Id)
        {
            return ToAddEditModel(_repo.Get(Id));
        }

        public List<Supplier> GetAll()
        {
            return _repo.GetAll();
        }

        public SupplierComplexResult Search(SupplierSearchModel sm, out int RecordCount)
        {
            return _repo.Search(sm,out RecordCount);
        }

    }
}

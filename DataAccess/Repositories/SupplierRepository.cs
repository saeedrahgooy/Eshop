using DataAccessSeviceContract.Services;
using DomainModel;
using DomainModel.DTOS.Supplier;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly EshopContext _db;
        public SupplierRepository(EshopContext db)
        {
            _db = db;
        }
        public OperationResult AddNew(Supplier current)
        {
            OperationResult op = new OperationResult("Add New Supplier");
            try
            {
                _db.Suppliers.Add(current);
                _db.SaveChanges();
                return op.Succeed("Supplier Added Successfully",current.SupplierID);
            }
            catch (Exception ex)
            {

                return op.Failed("Supplier Add Failed" + ex.Message,null);
            }
        }

        public bool CheckSupplierNameExistForOtherId(int Id, string SupplierName)
        {
            return _db.Suppliers.Any(x => x.SupplierID != Id && x.SupplierName == SupplierName);
        }

        public OperationResult Delete(int Id)
        {
            OperationResult op = new OperationResult("Delete", Id);
            var supplier = _db.Suppliers.FirstOrDefault(x => x.SupplierID == Id);
            if(supplier == null)
            {
                return op.Failed("Supplier ID Not Exist!",Id);
            }
            try
            {
                _db.Suppliers.Remove(supplier);
                _db.SaveChanges();
                return op.Succeed("Supplier Deleted Successfully", Id);
            }
            catch (Exception ex)
            {
                return op.Failed("Supplier Delete Failed" + ex.Message, Id);
            }
        }

        public Supplier Get(int Id)
        {
            return _db.Suppliers.FirstOrDefault(x => x.SupplierID == Id);
        }

        public List<Supplier> GetAll()
        {
            return _db.Suppliers.ToList();
        }

        public bool HasDuplicateName(string Name)
        {
            return _db.Suppliers.Any(x => x.SupplierName == Name);
        }

        public bool HasRelatedProduct(int Id)
        {
            return _db.Products.Any(x => x.SupplierID == Id);
        }

        public SupplierComplexResult Search(SupplierSearchModel sm, out int RecordCount)
        {
            try
            {
                var Suppliers = from item in _db.Suppliers select item;
                if (!string.IsNullOrEmpty(sm.SupplierName))
                {
                    Suppliers = Suppliers.Where(x => x.SupplierName.StartsWith(sm.SupplierName));
                }
                if (!string.IsNullOrEmpty(sm.Tel))
                {
                    Suppliers = Suppliers.Where(x => x.Tel.StartsWith(sm.Tel));
                }
                if (!string.IsNullOrEmpty(sm.Mobile))
                {
                    Suppliers = Suppliers.Where(x => x.Mobile.StartsWith(sm.Mobile));
                }
                var q = from item in Suppliers
                        select new SupplierListItem
                        {
                            SupplierID = item.SupplierID,
                            Tel = item.Tel,
                            Mobile = item.Mobile,
                            SupplierName = item.SupplierName,
                            ProductCount = item.Products.Count,
                        };
                RecordCount = q.Count();
                var r= q.OrderByDescending(x=>x.SupplierID).Skip(sm.PageSize * sm.PageIndex).Take(sm.PageSize).ToList();
                return new SupplierComplexResult
                {
                    Errors = null,
                    MainResult = r
                };
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add("خطا در بازیابی اطلاعات" + ex.Message);
                RecordCount = 0;
                return new SupplierComplexResult
                {
                    Errors =errors ,
                    MainResult = null
                };
                
            }
        }

        public OperationResult Update(Supplier current)
        {
            OperationResult op = new OperationResult("Update", current.SupplierID);
            try
            {
                _db.Suppliers.Attach(current);
                _db.Entry<Supplier>(current).State = EntityState.Modified;
                _db.SaveChanges();
                return op.Succeed("Supplier Update Successfully", current.SupplierID);
            }
            catch (Exception ex)
            {

                return op.Failed("Update Failed" + ex.Message, current.SupplierID);
            }
        }
    }
}

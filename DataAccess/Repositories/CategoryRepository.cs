using DataAccessSeviceContract.Services;
using DomainModel;
using DomainModel.DTOS.Category;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EshopContext _db;
        public CategoryRepository(EshopContext db)
        {
            _db = db;
        }
        public OperationResult AddNew(Category Current)
        {
            OperationResult op = new OperationResult("Add Category");
            try
            {
                _db.Categories.Add(Current);                
                _db.SaveChanges();
                return op.Succeed("Category Added SuccessFully", Current.CategoryID);
            }
            catch (Exception ex)
            {
                return op.Failed("Category Added Failed" + ex.Message, Current.CategoryID);
            }
        }

        public OperationResult Delete(int Id)
        {
            OperationResult op = new OperationResult("Delete Category",Id);
            var cat = _db.Categories.FirstOrDefault(x=>x.CategoryID == Id);
            if(cat == null)
            {
                return op.Failed("CategoryID Not Found", Id);
            }
            try
            {
                _db.Categories.Remove(cat);
                _db.SaveChanges();
                return op.Succeed("Category Deleted SuccessFully", Id);
            }
            catch (Exception ex)
            {

                return op.Failed("Category Deleted Failed" + ex.Message, Id) ;
            }
           
        }

        public Category Get(int Id)
        {
            return _db.Categories.FirstOrDefault(x => x.CategoryID == Id);
        }

        public List<Category> GetAll()
        {
            return _db.Categories.ToList();
        }

        public CategoryComplexResult GetChildren(int Id)
        {
            List<string> errors = new List<string>();
            var cat = _db.Categories.FirstOrDefault(x => x.CategoryID == Id);
            CategoryComplexResult result= new CategoryComplexResult();
            if (cat == null)
            {
                errors.Add("Invalid  category Id");
                result.Errors = errors;
                result.MainResult = null;
                return result;
                
            }
            if (!cat.Childern.Any())
            {
                errors.Add("This node has no children");
                result.Errors = errors;
                result.MainResult = null;
                return result;
            }
            result.MainResult = _db.Categories.Where(x => x.ParentID == Id).Select(x => new CategoryListItem
            {
                CategoryId = x.CategoryID,
                CategoryName = x.CategoryName,
                ParentID = x.ParentID.Value,
                ChildCount = x.Childern.Count,
                ParentNames = "",
                ProductCount = x.Products.Count
            }).ToList();
            //result.MainResult= cat.Childern.Select(x=> new CategoryListItem 
            //{
            //    CategoryId = x.CategoryID,
            //    CategoryName = x.CategoryName,
            //    ParentID = x.ParentID.Value,
            //    ChildCount = x.Childern.Count,
            //    ParentNames = "",
            //    ProductCount = x.Products.Count
            //}).ToList();
            return result;
        }

        public CategoryComplexResult GetParent(int Id)
        {
            List<string> errors = new List<string>();
            try
            {                
                var cat = _db.Categories.FirstOrDefault(x => x.CategoryID == Id);
                if (cat == null)
                {
                    errors.Add("Invalid Category Id");
                    return new CategoryComplexResult
                    {
                        Errors = errors,
                        MainResult = null
                    };
                }
                if (cat.ParentID == null || cat.Parent == null)
                {
                    errors.Add("Parent Node Dose Not Exist or Parent Id is Wrong!");
                    return new CategoryComplexResult
                    {
                        Errors = errors,
                        MainResult = null
                    };
                }
                List<CategoryListItem> Parents = new List<CategoryListItem>();
                CategoryListItem cli = new CategoryListItem
                {
                    CategoryId = cat.Parent.CategoryID,
                    CategoryName = cat.Parent.CategoryName,
                    ParentID = cat.Parent.ParentID.Value,
                    ChildCount = cat.Parent.Childern.Count,
                    ParentNames = "",
                    ProductCount = cat.Parent.Products.Count
                };
                Parents.Add(cli);
                return new CategoryComplexResult
                {
                    Errors = null,
                    MainResult = Parents
                };
            }
            catch (Exception ex)
            {
                errors.Add("خطا در بازیابی اطلاعات" + ex.Message);
                return new CategoryComplexResult
                {
                    Errors = errors,
                    MainResult = null
                };                
            }
        }

        public CategoryComplexResult GetParentList(int Id)
        {
            return null;
        }

        public bool HasChild(int Id)
        {
            return _db.Categories.Any(x => x.ParentID == Id);
        }

        public bool HasDuplicateName(string CategoryName)
        {
            return _db.Categories.Any(x => x.CategoryName == CategoryName);
        }

        public bool HasDuplicateName(int Id, string CategoryName)
        {
            return _db.Categories.Any(x => x.CategoryID != Id && x.CategoryName == CategoryName);
        }

        public bool HasProduct(int Id)
        {
            var cat = _db.Categories.FirstOrDefault(x => x.CategoryID == Id);
            return cat.Products.Any();
        }

        public CategoryComplexResult Search(CategorySearchModel sm, out int RecordCount)
        {
            List<string> errorList = new List<string>();
            List<CategoryListItem> categoryListItems;            
            try
            {
                
                var q = from item in _db.Categories
                        select new CategoryListItem
                        {
                            CategoryId = item.CategoryID,
                            CategoryName = item.CategoryName,
                            ChildCount = item.Childern.Count,
                            ParentNames = "",
                            ProductCount = item.Products.Count,
                            ParentID = item.ParentID.Value
                        };
                if (!string.IsNullOrEmpty(sm.CategoryName))
                {
                    q = q.Where(x => x.CategoryName.Contains(sm.CategoryName));
                }
                if (sm.ParentID != null)
                {
                    q = q.Where(x => x.ParentID == sm.ParentID.Value);
                }
                RecordCount = q.Count();
                categoryListItems = q.OrderByDescending(x => x.CategoryId).Skip(sm.PageSize * sm.PageIndex).Take(sm.PageSize).ToList();
                CategoryComplexResult results = new CategoryComplexResult 
                {
                    Errors = null,
                    MainResult = categoryListItems,
                };

                return results;
            }
            catch (Exception ex)
            {
                errorList.Add("خطا در بازیابی" + ex.Message);
                CategoryComplexResult results = new CategoryComplexResult
                {
                    Errors = errorList,
                    MainResult = null,
                };
                RecordCount = 0;
                return results;
            }
        }

        public OperationResult Update(Category Current)
        {
            OperationResult op = new OperationResult("Update Category", Current.CategoryID);

            try
            {
                _db.Categories.Attach(Current);
                _db.Entry<Category>(Current).State = EntityState.Modified;
                _db.SaveChanges();
                return op.Succeed("Category Updated SuccessFully", Current.CategoryID);
            }
            catch (Exception ex)
            {
                return op.Failed("Category Updated Failed" + ex.Message, Current.CategoryID);
            }
        }
    }
}

using BusSeviceContract.Services;
using DataAccessSeviceContract.Services;
using DomainModel.DTOS.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly ICategoryRepository repo;
        public CategoryBusiness(ICategoryRepository repo)
        {
            this.repo = repo;
        }
        public CategoryComplexResult GetChildren(int Id)
        {
            throw new NotImplementedException();
        }

        public CategoryComplexResult GetParent(int Id)
        {
            return repo.GetParent(Id);
        }

        public CategoryComplexResult GetParentList(int Id)
        {
            throw new NotImplementedException();
        }

        public bool HasChild(int Id)
        {
            throw new NotImplementedException();
        }

        public bool HasDuplicateName(string CategoryName)
        {
            throw new NotImplementedException();
        }

        public bool HasDuplicateName(int Id, string CategoryName)
        {
            throw new NotImplementedException();
        }

        public bool HasProduct(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

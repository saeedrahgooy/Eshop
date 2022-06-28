using DataAccessSeviceContract.Services.Base;
using DomainModel.DTOS.Category;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessSeviceContract.Services
{
    public interface ICategoryRepository : IBaseRepositorySearchable<Category,int,CategorySearchModel,CategoryComplexResult>
    {
        CategoryComplexResult GetParent(int Id);
        CategoryComplexResult GetChildren(int Id);
        CategoryComplexResult GetParentList(int Id);
        bool HasProduct(int Id);
        bool HasChild(int Id);
        bool HasDuplicateName(string CategoryName);
        bool HasDuplicateName(int Id, string CategoryName);
    }
}

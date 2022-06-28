using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTOS.Category
{
    public class CategoryComplexResult : IComplexObjectResult<List<CategoryListItem>, List<string>>
    {
        private List<CategoryListItem> mainResult;
        public List<CategoryListItem> MainResult {
            get { return this.mainResult; }
            set { this.mainResult = value; } 
        }
        private List<string> errors;
        public List<string> Errors { 
            get { return this.errors; }
            set { this.errors = value; }
        }
    }
}

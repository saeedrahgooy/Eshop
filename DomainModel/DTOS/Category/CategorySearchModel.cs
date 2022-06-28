using DomainModel.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTOS.Category
{
    public class CategorySearchModel : PageModel
    {
        public string CategoryName { get; set; }
        public int? ParentID { get; set; }

    }
}

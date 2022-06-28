using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTOS.Category
{
    public class CategoryListItem
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ParentNames { get; set; }
        public int ChildCount { get; set; }
        public int ProductCount { get; set; }
        public int? ParentID { get; set; }
    }
}

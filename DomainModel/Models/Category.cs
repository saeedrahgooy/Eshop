using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            Childern = new HashSet<Category>();
            CategoryFeatures = new HashSet<CategoryFeature>();
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string SmallDescription { get; set; }
        public ICollection<Category> Childern { get; set; }
        public int? ParentID { get; set; }
        public Category Parent { get; set; }
        public int Depth { get; set; }
        public string Lineage { get; set; }
        public int? ProductCount { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<CategoryFeature> CategoryFeatures { get; set; }

    }
}

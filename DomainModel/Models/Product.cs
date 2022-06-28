using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Product
    {
        public Product()
        {
            Products = new HashSet<RelatedProduct>();
            RelatedProducts = new HashSet<RelatedProduct>();
            ProductFeatureValues = new HashSet<ProductFeatureValue>();
            OrderDetails = new HashSet<OrderDetail>();
            ProductKeyWords = new HashSet<ProductKeyWord>();
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string SmallDescription { get; set; }
        public string Description { get; set; }
        public string MainPicture { get; set; }
        public string Picture { get; set; }
        public int? SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<RelatedProduct> RelatedProducts { get; set; }
        public ICollection<RelatedProduct> Products { get; set; }
        public ICollection<ProductFeatureValue> ProductFeatureValues { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<ProductKeyWord> ProductKeyWords { get; set; }
    }
}

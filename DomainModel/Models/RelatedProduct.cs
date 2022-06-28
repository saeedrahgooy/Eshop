using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class RelatedProduct
    {
        public int RelatedProductID { get; set; }
        public int ProductID { get; set; }
        public int RelatedToID { get; set; }
        public Product Product { get; set; }
        public Product RelatedTo { get; set; }
    }
}

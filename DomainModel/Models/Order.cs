using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public string OrderDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public DateTime? RequiredDate { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

    }
}

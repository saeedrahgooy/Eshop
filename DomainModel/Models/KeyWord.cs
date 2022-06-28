using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class KeyWord
    {
        public int KeyWordID { get; set; }
        public string KeyWordText { get; set; }
        public ICollection<ProductKeyWord> ProductKeyWords { get; set; }
        public KeyWord()
        {
            ProductKeyWords = new HashSet<ProductKeyWord>();
        }
    }
}

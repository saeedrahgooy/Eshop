using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.BaseModel
{
    public class PageModel
    {
        public int PageSize { get; set; }
        public int RecourCount { get; set; }
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models
{
    public class StudentBookComplexObject
    {
        public Book Book { get; set; }
        public Student Student { get; set; }
    }
}

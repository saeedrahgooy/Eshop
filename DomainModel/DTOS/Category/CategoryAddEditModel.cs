using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTOS.Category
{
    public class CategoryAddEditModel
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="*")]
        [Display(Name ="نام دسته ")]
        public string CategoryName { get; set; }
        [StringLength(maximumLength:100,MinimumLength =0,ErrorMessage ="حداکثر 100 حرف")]
        public string SmallDescription { get; set; }
        public int? ParentID { get; set; }
        
    }
}

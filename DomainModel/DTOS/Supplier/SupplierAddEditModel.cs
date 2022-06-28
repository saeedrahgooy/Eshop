using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTOS.Supplier
{
    public class SupplierAddEditModel
    {
        public int SupplierID { get; set; }
        [Required(ErrorMessage ="نام را وارد کنید")]
        [Display(Name ="نام تامین کننده")]
        public string SupplierName { get; set; }
        [Display(Name = "آدرس تامین کننده")]
        [Required(ErrorMessage ="آدرس را وارد کنید")]
        [StringLength(maximumLength:400,ErrorMessage =("حداکثر 400 و حداقل 10 کاراکتر"),MinimumLength =10)]
        public string Address { get; set; }
        [Display(Name = "موبایل")]
        //[RegularExpression(@"^([0-9]{10})$", ErrorMessage = "شماره موبایل صحیح نمی باشد")]
        public string Mobile { get; set; }
        [Display(Name ="تلفن")]
        public string Tel { get; set; }
    }
}

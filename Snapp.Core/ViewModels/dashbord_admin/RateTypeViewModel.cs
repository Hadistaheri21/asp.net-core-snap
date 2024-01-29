using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels.dashbord_admin
{
     public class RateTypeViewModel
    {
        [Display(Name = "گزینه امتیاز")]
        [Required(ErrorMessage ="نباید بدون مقدار باشد")]
        [MaxLength(40,ErrorMessage = "مقدار {0}  نباید بیش از {1} کاراکتر باشد")]
        public string Name { get; set; }

        //ترو بود مثبت نبود منفی
        [Display(Name = "مثبت")]
        public bool Ok { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int ViewOrder { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Snapp.Core.ViewModels.dashbord_admin
{
     public class AdminColorViewModel
    {
        [Display(Name = "نام رنگ")]
        [Required(ErrorMessage ="نباید بدون مقدار باشد")]
        [MaxLength(20,ErrorMessage = "مقدار {0}  نباید بیش از {1} کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "کد رنگ")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(10, ErrorMessage = "مقدار {0}  نباید بیش از {1} کاراکتر باشد")]
        public string Code { get; set; }
    }
}

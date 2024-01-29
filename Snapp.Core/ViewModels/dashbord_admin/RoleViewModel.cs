using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Snapp.Core.ViewModels.dashbord_admin
{
    public class RoleViewModel
    {
        [Display(Name = "عنوان سیستمی نقش")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(30, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "عنوان نمایشی نقش")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(30, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Title { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Snapp.Core.ViewModels.dashbord_admin
{
      public  class UserViewModel
      {
        
        public Guid Id { get; set; }

        [Display(Name = "نقش کاربر")]
        public Guid RoleId { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(11, ErrorMessage = "مقدار {0}  نباید بیش از {1} کاراکتر باشد")]
        [MinLength(11, ErrorMessage = "مقدار {0}  نباید کمتر از {1} کاراکتر باشد")]
        [Phone(ErrorMessage ="شماره همراه معتبر وارد نمایید")]
        public string Username { get; set; }

        [Display(Name = "فعال/غیرفعال")]
        public bool IsActive { get; set; }

      }
}

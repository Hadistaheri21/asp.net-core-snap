using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace Snapp.Core.ViewModels.dashbord_admin
{
   public class DriverImgViewModel
    {
        [Display(Name = "تصویر گواهینامه")]
        public IFormFile Img { get; set; }

        public string ImgName { get; set; }

        [Display(Name = "تأیید")]
        public bool IsConfirm { get; set; }
        

    }
}

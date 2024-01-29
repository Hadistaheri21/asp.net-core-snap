using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snapp.Core.ViewModels.Panel
{
   public class UserAddresseViewModel
    {
        [Display(Name = "عنوان یا نام")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Title { get; set; }

        public string Lat { get; set; }

        public string Lng { get; set; }

        public string Desc { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels.dashbord_admin
{
   public class TermsSettingViewModel
    {
        [Display(Name = "شرایط و قوانین استفاده")]
        [DataType(DataType.MultilineText)]
        public string Terms { get; set; }
    }
}

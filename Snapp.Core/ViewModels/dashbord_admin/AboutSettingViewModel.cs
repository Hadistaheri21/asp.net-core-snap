using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels.dashbord_admin
{
    public class AboutSettingViewModel
    {
        [Display(Name = "درباره ما")]
        [DataType(DataType.MultilineText)]
        public string About { get; set; }
    }
}

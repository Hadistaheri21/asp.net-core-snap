using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels.dashbord_admin
{
     public class PriceSettingViewModel
    {
        [Display(Name = "محاسبه آب و هوا در قیمت")]
        public bool IsWeatherPirce { get; set; }

        [Display(Name = "محاسبه بُعد مسافت در قیمت")]
        public bool IsDistance { get; set; }
    }
}

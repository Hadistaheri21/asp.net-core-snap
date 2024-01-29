﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels.dashbord_admin
{
     public class MonthTypeViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "از ")]
        public int Start { get; set; }

        [Display(Name = "تا ")]
        public int End { get; set; }

        [Display(Name = "درصد")]
        public float Percent { get; set; }
    }
}

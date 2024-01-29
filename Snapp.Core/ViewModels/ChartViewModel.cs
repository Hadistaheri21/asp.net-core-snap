using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels
{
   public class ChartViewModel
    {
        //عنوان چارت
        public string Label { get; set; }

        //مقادیر نال پذیر=؟
        public int? Value { get; set; }

        public string Color { get; set; }
    }
}

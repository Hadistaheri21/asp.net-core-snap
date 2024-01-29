using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.ViewModels.Payment
{
   public class VerifyResultDate
    {
        public int ResCode { get; set; }
        public string Decription { get; set; }

        //مبلغ
        public string Amount { get; set; }
        public string RetrivalRefNo { get; set; }

        //شماره ارجاع
        public string SystemTraceNo { get; set; }
        public string OrderId { get; set; }
    }
}

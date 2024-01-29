using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kavenegar;

namespace Snapp.Core.senders
{
    public static class smssender
    {
        public static void verifysend(string to,string template,string token)
        {
            var api = new KavenegarApi("");

            var strto = to;
            var strtemplate = template;
            var strtoken = token;

            api.VerifyLookup(strto, strtoken, strtemplate);

        }
    }
}

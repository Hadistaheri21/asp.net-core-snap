using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Snapp.Core.securities
{
    public static class HashEncode
    {
        public static string gethashcode(string Password)
        {
            byte [] mainbytes;
            byte[] encodebytes;

            MD5 md5;

            md5 = new MD5CryptoServiceProvider();
           
                mainbytes = ASCIIEncoding.Default.GetBytes(Password);
                encodebytes = md5.ComputeHash(mainbytes);
                return BitConverter.ToString(encodebytes);
           

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.Security
{
    //static=نیازی به نمونه سازی نیست
    public static class CheckNationalCode
    {

        //کد ملی را بگیر:معتبر هست یا نه
        public static bool CheckCode(string code)
        {
            //Array
            var digitStrings = new[] {"0000000000","1111111111","2222222222","4444444444","5555555555","6666666666",
            "7777777777","8888888888","9999999999"};

            if(digitStrings.Contains(code))
            {
                return false;
            }

            var StrCode = code.ToCharArray();

            //5120080324
            var num0 = Convert.ToInt32(StrCode[0].ToString()) * 10; //10=موقعیت دهم شمارش  از سمت راست...> 5*10
            var num9 = Convert.ToInt32(StrCode[1].ToString()) * 9; //9=موقعیت نهم 1*9
            var num8 = Convert.ToInt32(StrCode[2].ToString()) * 8; //8=موقعیت 8
            var num7 = Convert.ToInt32(StrCode[3].ToString()) * 7; //7=موقعیت 7
            var num6 = Convert.ToInt32(StrCode[4].ToString()) * 6; //6=موقعیت 6
            var num5 = Convert.ToInt32(StrCode[5].ToString()) * 5; //5=موقعیت 5
            var num4 = Convert.ToInt32(StrCode[6].ToString()) * 4; //4=موقعیت 4
            var num3 = Convert.ToInt32(StrCode[7].ToString()) * 3; //3=موقعیت 3
            var num2 = Convert.ToInt32(StrCode[8].ToString()) * 2; //2=موقعیت 2

            //عدد نهم
            var a = Convert.ToInt32(StrCode[9].ToString()); //عدد کنترل ما هست که در اینجا عدد 4 است
            //جمع حاصلضرب ها
            var b = num0 + num9 + num8 + num7 + num6 + num5 + num4 + num3 + num2;
             //11 عددی ثابت است
            var c = b % 11;

            //ریترن کن حالت های مختلف را
            return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
        }
    }
}

using System;
using System.Globalization;

namespace Snapp.Core.Generators
{
    public static class DatetimeGenarator
    {
        public static string GetShamsiDate()
        {
            // 0000/00/00  تاریخ
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(DateTime.Now).ToString("0000") + "/" +
                   pc.GetMonth(DateTime.Now).ToString("00") + "/" +
                   pc.GetDayOfMonth(DateTime.Now).ToString("00");
        }

        public static string GetShamsiTime()
        {
            //00:00:00 ساعت مثال 14

            PersianCalendar pc = new PersianCalendar();
            return pc.GetHour(DateTime.Now).ToString("00") + ":" +
                   pc.GetMinute(DateTime.Now).ToString("00") + ":" +
                   pc.GetSecond(DateTime.Now).ToString("00");
        }
    }
}

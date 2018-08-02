using System;
using System.Collections.Generic;
using System.Globalization;

namespace BLL.Common
{
    public class Date
    {
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }

        public List<string> GetListDate(int nam)
        {
            List<string> lstTuan = new List<string>();
            int tongSoTuan = SoTuanCuaNam(nam);
            DateTime dt = new DateTime();
            DateTime.TryParse(nam.ToString() + "/01/01", out dt);

            for (int i = 0; i < tongSoTuan; i++)
            {
                //trong khi ngày đầu tiên của năm không phải thứ 2 thì cộng tiếp 1 ngày cho đến thứ 2
                while (dt.DayOfWeek != DayOfWeek.Monday)
                {
                    dt = dt.AddDays(1);
                }
                DateTime dtEnd = dt.AddDays(6);
                string dayOfWeek = "Từ : -" + dt.Month.ToString() + "/" + dt.Day.ToString() + "/" + dt.Year.ToString()
                    + "- đến : -" + dtEnd.Month.ToString() + "/" + dtEnd.Day.ToString() + "/" + dtEnd.Year.ToString();
                lstTuan.Add(dayOfWeek);

                dt = dtEnd.AddDays(1);
            }
            return lstTuan;
        }

        public List<Date> GetDateBeforeAfterOfWeeksInYear(int nam)
        {
            List<Date> lstTuan = new List<Date>();
            int tongSoTuan = SoTuanCuaNam(nam);
            DateTime dt = new DateTime();
            DateTime.TryParse(nam.ToString() + "/01/01", out dt);

            for (int i = 0; i < tongSoTuan; i++)
            {
                //trong khi ngày đầu tiên của năm không phải thứ 2 thì cộng tiếp 1 ngày cho đến thứ 2
                while (dt.DayOfWeek != DayOfWeek.Monday)
                {
                    dt =dt.AddDays(1);
                }
                DateTime dtEnd = dt.AddDays(6);
                Date date = new Date();
                date.NgayBD = dt;
                date.NgayKT = dtEnd;  
                lstTuan.Add(date);  
                dt = dtEnd.AddDays(1);
            }
            return lstTuan;
        }

        public int SoTuanCuaNam(int nam)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = new DateTime(nam, 12, 31);
            Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }

       
    }
}
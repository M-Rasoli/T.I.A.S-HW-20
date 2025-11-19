using System.Globalization;

namespace App.EndPoints.Presentation.MVC.Tools
{
    public static class PersianDateToGregorian
    {
        public static DateTime ConvertPersianDateToGregorian(string persianDate)
        {
            var persian = new PersianCalendar();
            var parts = persianDate.Split('/');
            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);

            return persian.ToDateTime(year, month, day, 0, 0, 0, 0);

        }
    }
}

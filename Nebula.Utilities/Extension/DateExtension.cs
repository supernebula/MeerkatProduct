using System;

namespace Nebula.Utilities.Extension
{
    public static class DateExtension
    {
        public static string TimeStamp(this DateTime dateTime)
        {
            return String.Format("{0}{1}{2}{3}{4}{5}", dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
        }
    }
}

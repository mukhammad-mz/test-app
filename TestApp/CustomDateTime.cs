using System.Globalization;



public static class CustomDateTime
{
    public static DateTime Now()
    {
        return DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
    }

    public static string ParseDateTo_ddMMyyyy(string dateString)
    {
        if (string.IsNullOrEmpty(dateString))
        {
            return "";
        }
        return DateTime.Parse(dateString).ToString("dd.MM.yyyy");
    }

    public static DateTime NowWithMillisecond()
    {
        return DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffffff"), "yyyy-MM-dd HH:mm:ss:ffffff", CultureInfo.InvariantCulture);
    }



    public static string ConvertToExpDate(DateTime dateTime)
    {
        return Convert.ToDateTime(dateTime).ToString("yyMM");
    }

    public static string ConvertToExpDate(DateTime dateTime, string format)
    {
        return Convert.ToDateTime(dateTime).ToString(format);
    }

    public static string ConvertToExpDate(DateTime dateTime, char delimiter)
    {
        return dateTime.ToString("MM.yy").Replace('.', delimiter);
    }

    public static int GetDayOfWeek(DateTime dateTime)
    {
        DateTimeFormatInfo dateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo;
        Calendar calendar = dateTimeFormatInfo.Calendar;
        return calendar.GetWeekOfYear(dateTime, dateTimeFormatInfo.CalendarWeekRule, dateTimeFormatInfo.FirstDayOfWeek);
    }
}


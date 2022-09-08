using System;

namespace Utils.TimeSpanUtils
{
    static public class TimeSpanUtils
    {
        static public string GetRuntime(TimeSpan timeSpan)
        {
            if (timeSpan.TotalMinutes <= 0)
                return "N/A";
            if (timeSpan.TotalMinutes < 60)
                return timeSpan.Minutes + " min";
            return timeSpan.Hours + " h " + timeSpan.Minutes + " min";
        }
    }
}

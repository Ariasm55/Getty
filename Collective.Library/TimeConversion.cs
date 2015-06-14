using System;

namespace Collective.Library
{
    public class TimeConversion
    {
        public static DateTime TimetoEst( DateTime timenow)
        {
            //var currentTimeZone = TimeZone.CurrentTimeZone.GetUtcOffset(timenow).ToString();
            //var estzone2 = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time").SupportsDaylightSavingTime;
            //var estzone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            //var conver = TimeZoneInfo.ConvertTime(timenow, estzone);
            //GlobalVariables.GlobalsLib.Timing = conver;
            var dto = new DateTimeOffset(timenow);  // will use .Kind to decide the offset
            var converted = dto.ToOffset(TimeSpan.FromHours(-5));
            GlobalVariables.GlobalsLib.Timing = converted.DateTime;
            return converted.DateTime;
            
            


        }
    }
}

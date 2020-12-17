using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Planner.Util

/**
 * Author tahidixon
 * 12.12.2020
 * Purpose: To provide an object instance that can convert strings presented in epoch milliseconds to a usable datetime 
 */
{
    internal class TimeUtil
    {

        //Default time format
        static string DATETIME_FORMAT = "MMM dd yyyy HH:mm:ss zzz";
        //Calendar instances
        private DateTime date = new DateTime();
        private DateTimeOffset dto = new DateTimeOffset();
        private long EPOCH;

        public TimeUtil()
        {

        }
        //Returns the current time in string format
        public string getCurrentTimeString()
        {
            this.date = DateTime.UtcNow;
            return date.ToString(DATETIME_FORMAT);
        }
        //Returns the current time in epoch ms
        public string getCurrentTime()
        {
            this.EPOCH = DateTime.UtcNow.Ticks - new DateTime(1970, 1, 1, 0, 0, 0, 0, 0).Ticks;
            return EPOCH.ToString();
        }
        // Returns the provided year, month, day, hour, minute, and second in epoch ms format
        // @param year   = the requested year   (DEFAULT = 1970)
        // @param month  = the requested month  (DEFAULT = 1)
        // @param day    = the requested day    (DEFAULT = 1)
        // @param hour   = the requested hour   (DEFAULT = 0)
        // @param minute = the requested minute (DEFAULT = 0)
        // @param second = the requested second (DEFAULT = 0)
        public string getFormattedEpoch(int year = 1970, int month = 1, int day = 1, int hour = 0, int minute = 0, int second = 0)
        {
            this.dto = new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);
            return dto.ToString(DATETIME_FORMAT);
        }

        // Returns the current timezone offset for users. Commented out since I'm the only user and don't need to handle timezones yet
        //public string getTimezoneOffset();

        // Returns the difference between two epoch strings
        //@param start  = the start timestamp in epoch ms
        //@param end    = the end timestamp in epoch ms
        //@param output = the type of output the method will return - in epochs, or days/minutes/seconds (DEFAULT = "DATETIME")
        public string getTimeDifference(string start, string end, string output = "DATETIME")
        {
            long startTime, endTime;

            if (!Int64.TryParse(start, out startTime)) Console.WriteLine("Cannot convert the 'start' param");
            if (!Int64.TryParse(end, out endTime)) Console.WriteLine("Cannot convert the 'end' param");

            if (output == "EPOCH")
                return (endTime - startTime).ToString();
            else
            {
                TimeSpan timeDifference = TimeSpan.FromMilliseconds(endTime - startTime);
                return timeDifference.ToString(DATETIME_FORMAT);
            }



        }

        //Converts a given DateTime to an epoch ms string
        public string convertToEpoch (DateTime time)
        {
            return DateTime.UtcNow.Ticks.ToString();
        }

    }
}
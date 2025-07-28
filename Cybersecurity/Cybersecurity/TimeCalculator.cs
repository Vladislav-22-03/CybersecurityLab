using System;
using System.Collections.Generic;

namespace Cybersecurity
{
    public static class TimeCalculator
    {
        private static HashSet<DateTime> Holidays = new()
        {
            new DateTime(2025, 8, 1),
            new DateTime(2025, 8, 2),
            new DateTime(2025, 8, 3)
        };

        public static DateTime CalculateEndTime(DateTime start, int hours)
        {
            DateTime current = start;
            int hoursLeft = hours;

            while (hoursLeft > 0)
            {
                if (IsWorkingHour(current))
                {
                    hoursLeft--;
                }
                current = current.AddHours(1);
            }

            return current;
        }

        private static bool IsWorkingHour(DateTime time)
        {
            return time.DayOfWeek != DayOfWeek.Saturday &&
                   time.DayOfWeek != DayOfWeek.Sunday &&
                   time.Hour >= 9 && time.Hour < 17 &&
                   !Holidays.Contains(time.Date);
        }
    }
}

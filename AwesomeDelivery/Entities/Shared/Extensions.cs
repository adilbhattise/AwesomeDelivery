using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDelivery.Entities.Shared
{
    public static class ExtensionMethod
    {
        public static DateTime GetNextWeekDayDate(this DayOfWeek dayOfWeek, int daysInAdvance)
        {
            // Getting the difference with the desired upcoming day of Week

            int today = (int)DateTime.Today.DayOfWeek;
            int target = (int)dayOfWeek;
            target = target <= today ? target + 7 : target;
            int daysToAdd = target - today;

            // Calculting the Days in Advance with respect to upcomming desired day

            DateTime expectedDate = DateTime.Today.AddDays(daysToAdd);
            DateTime minimumDate = DateTime.Today.AddDays(daysInAdvance);
            if (expectedDate < minimumDate)
            {
                daysToAdd += 7;
            }

            // Getting the Exact Date of the Day 

            DateTime nextDate = DateTime.Today.AddDays(daysToAdd);
            return nextDate;
        }
    }
}

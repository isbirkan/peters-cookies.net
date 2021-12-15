using Nager.Date;

namespace Peters.Cookies.Domain.Helpers;

public static class DateExtensions
{
    public static bool IsPublicHolidayInNetherlands(this DateTime theDay)
    {
        return DateSystem.IsPublicHoliday(theDay, CountryCode.NL);
    }

    public static bool IsSunday(this DateTime theDay)
    {
        return theDay.DayOfWeek == DayOfWeek.Sunday;
    }

    public static bool IsFuture(this DateTime theDay)
    {
        return theDay.Date > DateTime.Now.Date;
    }
}
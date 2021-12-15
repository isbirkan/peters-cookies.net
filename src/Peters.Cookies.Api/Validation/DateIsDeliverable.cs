using System.ComponentModel.DataAnnotations;
using Peters.Cookies.Domain.Helpers;

namespace Peters.Cookies.Api.Validation;

public class DateIsDeliverable : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        // In a perfect scenario we might not use a separate package in order to achieve this
        // We could have some static data set in the Database and retrieve the days from there

        if (value is DateTime deliveryDate) 
        {
            return !deliveryDate.IsPublicHolidayInNetherlands() &&
                   !deliveryDate.IsSunday() &&
                    deliveryDate.IsFuture();
        }

        return false;
    }
}

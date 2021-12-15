using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Peters.Cookies.Api.Validation;

public class ListHasElements : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value != null)
        {
            return value is IList list && list != null && list.Count > 0;
        }

        return false;
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Peters.Cookies.Domain.Helpers;

namespace Peters.Cookies.Api.Validation;

public class ModelStateValidationAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        Assertion.ArgumentNullAssert(context, nameof(context));

        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}

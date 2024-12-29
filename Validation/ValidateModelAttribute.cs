
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace books.Validation;

public class ValidateModelAttribute : ActionFilterAttribute
{
    override
        public void OnActionExecuting(ActionExecutingContext context)
    {

        if (!context.ModelState.IsValid == false)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}

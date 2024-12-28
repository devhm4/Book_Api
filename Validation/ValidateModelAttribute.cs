
using Microsoft.AspNetCore.Mvc.Filters;

namespace books.Validation;

public class ValidateModelAttribute : ActionFilterAttribute
{
    override
        public void OnActionExecuting(ActionExecutingContext context)
    {

        if (!context.ModelState.IsValid == false)
        {
            context.Result = new Microsoft.AspNetCore.Mvc.BadRequestResult();
        }
    }

}

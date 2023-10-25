using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AxeraApi.CustomActionFilters;

public class ValidationModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if(context.ModelState.IsValid == false) 
        { 
            context.Result = new BadRequestResult();
        }      
    }
}

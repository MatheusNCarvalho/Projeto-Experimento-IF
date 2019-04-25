using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IFExperiment.Api.Controllers
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (context.ModelState.IsValid)
            {

            }

            base.OnActionExecuting(context);
        }
    }
}

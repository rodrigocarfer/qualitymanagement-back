using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using QualityManagement.API.Resources;
using QualityManagement.Util.Exceptions;

namespace QualityManagement.API.Filters
{
    public class ApplicationTokenFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string token = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "access_token").Value;

            if (!TokenConfigurator.ValidToken(token))
                throw new NotAuthorizedException();

            base.OnActionExecuting(context);
        }
    }
}
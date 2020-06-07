using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using QualityManagement.Util.Exceptions;

namespace QualityManagement.API.Filters
{
    public class MicrosoftTokenFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try { 
                string jwt = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "x-jwt").Value;
                var jwtHandler = new JwtSecurityTokenHandler();

                if (!jwtHandler.CanReadToken(jwt))
                    throw new NotAuthorizedException();

                var token = jwtHandler.ReadJwtToken(jwt);
                var claimTenantId = token.Claims.FirstOrDefault(c => c.Type == "tid");

                if(claimTenantId?.Value != "c6378a59-9025-42be-b941-103b280edffa")
                    throw new NotAuthorizedException();
            } 
            catch
            {
                throw new NotAuthorizedException();
            }

            base.OnActionExecuting(context);
        }
    }
}
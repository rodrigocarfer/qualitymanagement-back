using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QualityManagement.Util.Exceptions;

namespace QualityManagement.API.Extensions
{
    public static class ExceptionHandlerExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        string json;
                        int statusCode;

                        if (VerificarNaoAutorizado(exceptionHandlerFeature))
                        {
                            statusCode = StatusCodes.Status401Unauthorized;

                            json = JsonConvert.SerializeObject(new {statusCode, message = "Request Not Authorized."});
                        }
                        else
                        {
                            statusCode = StatusCodes.Status500InternalServerError;

                            json = JsonConvert.SerializeObject(new
                            {
                                statusCode, message = "Erro Interno ao Processar a requisição."
                            });
                        }

                        context.Response.StatusCode = statusCode;
                        context.Response.ContentType = "application/json";

                        await context.Response.WriteAsync(json);
                    }
                });
            });

            app.UseHsts();
        }

        private static bool VerificarNaoAutorizado(IExceptionHandlerFeature exceptionHandlerFeature) =>
            exceptionHandlerFeature != null && exceptionHandlerFeature.Error != null &&
            exceptionHandlerFeature.Error.Message != null && 
            exceptionHandlerFeature.Error.Message.Contains(typeof(NotAuthorizedException).FullName);
    }
}
using Contracts;
using Microsoft.AspNetCore.Diagnostics;
using Entities.ErrorModel;
using System.Net;
using Entities.Exceptions;

namespace Company_Employees.Extensions
{
    public static class ExceptionMeddlewareExtenssion
    {
        public static void ConfigueExceptionHandler(this WebApplication app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "/application.json";

                    var contexteFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if(contexteFeature != null)
                    {
                        context.Response.StatusCode = contexteFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogError($"Something went Wrong : {contexteFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contexteFeature.Error.Message,
                        }.ToString());
                    }
                });
            });
        }
    }
}

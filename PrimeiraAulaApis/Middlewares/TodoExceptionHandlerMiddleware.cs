using Microsoft.AspNetCore.Mvc;
using PrimeiraAulaApis.Logic.Exceptions;
using System.Net.Mime;

namespace PrimeiraAulaApis.Middlewares
{
    public class TodoExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public TodoExceptionHandlerMiddleware(RequestDelegate next) => this.next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (TodoValidationException ex)
            {
                var details = new ProblemDetails()
                {
                    Title = "Validation Error",
                    Detail = ex.Message,
                    Status = StatusCodes.Status400BadRequest,

                };

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(details));
            }
            catch (Exception ex)
            {
            }
        }
    }
}
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

using PizzaHut.PizzaApp.Core.Exceptions;
using PizzaHut.PizzaApp.Data.Exceptions;

namespace PizzaHut.PizzaApp.Presentation.Middleware
{
    public class MiddlewareExceptionHandler
    {
        private const string _jsonContentType = "application/json";

        private readonly RequestDelegate _next;

        public MiddlewareExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var ErrorResponse = new MiddlewareResponse<string>(null);

            if (ex is DataException dataException)
            {
                ErrorResponse.Status = (int)dataException.HttpResponse;
                ErrorResponse.Error.Message = $"Data Error{Environment.NewLine}Message: {ex.Message}{Environment.NewLine}";
            }
            else if (ex is CoreException coreException)
            {
                ErrorResponse.Status = (int)coreException.HttpResponse;
                ErrorResponse.Error.Message = $"Business Logic Error{Environment.NewLine}Message: {ex.Message}{Environment.NewLine}";
            }
            else
            {
                ErrorResponse.Status = (int)HttpStatusCode.InternalServerError;
                ErrorResponse.Error.Message = $"Unknown Error{Environment.NewLine}Message: {ex.Message}{Environment.NewLine}";
                //Log Error
                Console.WriteLine($"{ErrorResponse.Error.Message}{Environment.NewLine} Stack trace: {Environment.NewLine}{ex.StackTrace}");
            }

            context.Response.ContentType = _jsonContentType;
            context.Response.StatusCode = ErrorResponse.Status;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(ErrorResponse));
        }
    }
    public static class ATExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MiddlewareExceptionHandler>();
        }
    }
}

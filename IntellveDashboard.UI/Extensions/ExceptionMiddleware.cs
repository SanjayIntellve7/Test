using CustomLogContracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace IntellveDashboard.UI.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _loggerManager;

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager loggerManager)
        {
            _next = next;
            _loggerManager = loggerManager;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (FileNotFoundException ex)
            {
                _loggerManager.LogError($"Something went wrong File Not Found Exception is : {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (SqlException ex)
            {
                _loggerManager.LogError($"Something went wrong Sql Exception is : {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong Exception is : {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error from the custom middleware."
            }.ToString());
        }
    }
}
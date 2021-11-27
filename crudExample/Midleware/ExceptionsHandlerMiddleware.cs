using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace crudExample.Midleware
{
    public class ExceptionsHandlerMidleware
    {
        private readonly RequestDelegate _next;

        public ExceptionsHandlerMidleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exceptions)
        {

        }
    }
}

using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate _next)
        {
            this._next = _next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(CustomHttpRequestException ex)
            {
                HandleRequestExceptionAsync(httpContext, ex);
            }
        }

        private static void HandleRequestExceptionAsync(HttpContext httpContext, CustomHttpRequestException ex)
        {
            if(ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                httpContext.Response.Redirect($"/login?ReturnUrl={httpContext.Request.Path}");
                return;
            }

            httpContext.Response.StatusCode = (int)ex.StatusCode;
        }
    }
}

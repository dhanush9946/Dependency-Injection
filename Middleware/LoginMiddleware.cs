using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Employee3Dep.Middleware
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate next;
        public LoginMiddleware(RequestDelegate _next)
        {
            next = _next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Request:{context.Request.Path}");
            await next(context);
            Console.WriteLine($"Response:{context.Response.StatusCode}");
        }

    }
}

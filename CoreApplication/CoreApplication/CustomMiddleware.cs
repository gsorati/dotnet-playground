using Microsoft.AspNetCore.Http;

namespace CoreApplication
{
    public class CustomMiddleware
    {
        public readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate deligate) => _next = deligate;

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Custom Middleware Executing Before Next");
            await this._next(context);
        }
    }
}

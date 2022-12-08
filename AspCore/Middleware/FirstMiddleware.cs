using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcore.Middleware
{

    public class FirstMiddleware

    {
        private readonly RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"URL: {context.Request.Path}");
            context.Items.Add("DatafirstMiddleware", context.Request.Path);
            await context.Response.WriteAsync($"<p> {context.Request.Path}</p>");
            await _next(context);
        }
    }
}
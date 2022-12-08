using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcore.Middleware
{
    public class SecondMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/aaa")
            {
                // context.Response.Headers.Add("SecondMiddleware", "Ban khong duoc truy cap");
                var dataMiddlefirst = context.Items["DatafirstMiddleware"];
                if (dataMiddlefirst != null)
                {
                    // await context.Response.WriteAsync((string)dataMiddlefirst);

                    await context.Response.WriteAsync("ban khong duoc truy cao");

                }
                else
                {
                    // context.Response.Headers.Add("SecondMiddleware", "Ban khong duoc truy cap");
                    await next(context);

                }
            }
        }
    }
}
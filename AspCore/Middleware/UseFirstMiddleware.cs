using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcore.Middleware
{
    public static class UseFirstMiddleware
    {
        public static void UseFirstMiddlewareMethod(this IApplicationBuilder app)
        {
            app.UseMiddleware<FirstMiddleware>();
        }
        public static void UseSecondMiddlewareMethod(this IApplicationBuilder app)
        {
            app.UseMiddleware<SecondMiddleware>();
        }
    }
}
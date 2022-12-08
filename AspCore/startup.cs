using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspcore.Middleware;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace aspcore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            /*
                Phương thức ConfigureServices cho phép truy cập đến các dịch vụ, dependency được Inject vào
                Webhost. Hoặc bạn cũng có thể đưa thêm các dependency tại đây.
            */

            services.AddDistributedMemoryCache();       // Thêm dịch vụ dùng bộ nhớ lưu cache (session sử dụng dịch vụ này)
            services.AddSession();                      // Thêm  dịch vụ Session, dịch vụ này cunng cấp Middleware: 
            services.AddSingleton<SecondMiddleware>();


        }

        // IHostingEnvironment  env cho phép truy cập các biến môi trường, thư mục nguồn, thư mục file.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            // app.UseMiddleware<FirstMiddleware>();
            // app.UseFirstMiddlewareMethod();
            // app.UseSecondMiddlewareMethod();
            app.UseEndpoints(endpoints =>
            {


                endpoints.MapMethods("/Testpost", new string[] { "post", "put" }, async context =>
                {
                    await context.Response.WriteAsync("post/pust");
                });

                endpoints.MapGet("/product/{productId:int}", async context =>
                {
                    var idproduct = context.Request.RouteValues["productid"];
                    Console.WriteLine(idproduct);
                    await context.Response.WriteAsync("Hello baby aa bbb aa!" + idproduct);
                });
                endpoints.MapGet("/Cookies/{*action}", async context =>
                {
                    string menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);
                    string cookies = RequestProcess.Cookies(context.Request, context.Response).HtmlTag("div", "container");
                    string html = HtmlHelper.HtmlDocument("Đọc / Ghi Cookies", (menu + cookies));
                    await context.Response.WriteAsync(html);

                    await context.Response.WriteAsync($"Hello Hoang! ");

                });

                //     endpoints.MapPost("/form", async context =>
                //   {
                //       var formhtml = RequestProcess.ProcessForm(context.Request);
                //       var html = HtmlHelper.HtmlDocument("test submit", formhtml);

                //       await context.Response.WriteAsync(html);

                //   });
            });


            // phan 2 



            app.Run(async context =>
            {
                var formhtml = RequestProcess.ProcessForm(context.Request);
                var html = HtmlHelper.HtmlDocument("test submit", await formhtml);

                await context.Response.WriteAsync(html);

                await context.Response.WriteAsync($"Hello Hoang! ");

            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloWorld
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            /*
                Phương thức ConfigureServices cho phép truy cập đến các dịch vụ, dependency được Inject vào
                Webhost. Hoặc bạn cũng có thể đưa thêm các dependency tại đây.
            */

        }

        // IHostingEnvironment  env cho phép truy cập các biến môi trường, thư mục nguồn, thư mục file.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var Configuration = context.RequestServices.GetService<IConfiguration>();
                    var testOptions = Configuration.GetSection("TestOptions");
                    var key1 = testOptions["key1"];
                    var key2_one = testOptions.GetSection("key2")["name"];
                    var key2_address = testOptions.GetSection("key2")["address"];
                    var key2 = new StringBuilder();
                    key2.Append(key2_one);
                    key2.Append(":" + key2_address);

                    await context.Response.WriteAsync("Hello World!" + key1 + key2.ToString());
                });
            });
        }
    }
}
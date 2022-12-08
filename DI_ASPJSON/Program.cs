using HelloWorld;

public class program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            // webBuilder đối tượng lớp WebHostBuilder để cấu hình, đăng ký các dịch vụ ứng dụng Web
            // UseStartup chỉ ra lớp khởi chạy ứng dụng (đăng ký dịch vụ)
            webBuilder.UseStartup<Startup>();
        });
}
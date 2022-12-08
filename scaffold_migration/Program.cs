using Microsoft.EntityFrameworkCore;
using scaffold_migration.Models;

namespace Scaffold_Migration
{
    class program
    {
        public static async Task findEmployee()
        {
            using (var dbContext = new NhanvienContext())
            {
                var employee = await dbContext.Employees.ToListAsync();



                foreach (var e in employee)
                {
                    Console.WriteLine(e.EmpId);
                }



            }
        }
        public static async Task Main(string[] args)
        {     // connect den database co san de tao ra cac entity
              // dotnet ef dbcontext scaffold -o Models -f -d "Data Source=localhost,1433;Initial Catalog=NHANVIEN;User ID=sa;Password=1234; TrustServerCertificate=True" "Microsoft.EntityFrameworkCore.SqlServer"

            // Cap nhap nhung thay doi cua phien ban
            // dotnet ef migrations add [ten phien ban

            // cap nhat thay doi
            // dotnet ef database update 

            //Xóa Migration cuối với lệnh

            // dotnet ef migrations remove
            // Liệt kê các Migration

            // dotnet ef migrations list


            //Nếu muốn tạo SQL Script cho Migration thì gõ

            // dotnet ef migrations script--output migrations.sql
            await findEmployee();


        }
    }

}



using EF.Entity;
using EF.service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EF
{
    class Program
    {
        // public static async Task CreateDatabase()
        // {
        //     using (var dbContext = new ProductContext())
        //     {
        //         String databasename = dbContext.Database.GetDbConnection().Database;// mydata
        //         Console.WriteLine("Database created " + databasename);
        //         bool result = await dbContext.Database.EnsureCreatedAsync();
        //         // Console.Write($"Có chắc chắn xóa {databasename} (y) ? ");
        //         // string input = Console.ReadLine();
        //         //  bool result = await dbContext.Database.EnsureDeletedAsync(); // xoa db
        //         string resultString = result ? "tao thanh cong" : " tao tat bai";
        //         Console.WriteLine(databasename + ": " + resultString);


        //     }
        // }
        // public static async Task InsertProduct()
        // {
        //     using (var dbContext = new ProductContext())
        //     {
        //         await dbContext.products.AddAsync(new Product
        //         {
        //             NAME = "San pham 1",
        //             Provider = "SAM SUNG"

        //         });

        //         await dbContext.products.AddAsync(new Product
        //         {
        //             NAME = "San pham 2",
        //             Provider = "SAM SUNG"

        //         });
        //         //                 Nếu muốn thêm một lúc nhiều dữ liệu thì dùng AddRangeAsync, nó có thể nhận đối số là mảng các đối tượng cần chèn vào

        //         // var p1 = new Product() { Name = "Sản phẩm 3", Provider = "CTY A" };
        //         //                 var p2 = new Product() { Name = "Sản phẩm 4", Provider = "CTY A" };
        //         //                 var p3 = new Product() { Name = "Sản phẩm 5", Provider = "CTY B" };

        //         //                 await context.AddRangeAsync(new object[] { p1, p2, p3 });
        //         int row = await dbContext.SaveChangesAsync();
        //         Console.WriteLine($"so san pham duoc them la {row}");

        //     }

        // }
        // public static async Task FindAllProduct()
        // {
        //     using (var dbContext = new ProductContext())
        //     {
        //         var products = await dbContext.products.ToListAsync();
        //         foreach (var product in products)
        //         {
        //             Console.WriteLine($"{product.NAME,5} : {product.Provider,5}");
        //         }
        //         // dung linq
        //         var linq = await (from product in dbContext.products
        //                           where product.NAME == "San pham 2"
        //                           select product).ToListAsync();
        //         linq.ForEach(e =>
        //         {
        //             Console.WriteLine($"{e.NAME,5} : {e.Provider,5}");
        //         });

        //     }
        // }
        // public static async Task UpdateProductById(int ID, string NAME)
        // {
        //     using (var dbContext = new ProductContext())
        //     {
        //         // var products = await (from p in dbContext.products
        //         //                       where p.PR_ID == ID
        //         //                       select p).FirstOrDefaultAsync();
        //         // if (products != null)
        //         // {
        //         //     products.NAME = NAME;
        //         //     await dbContext.SaveChangesAsync();
        //         // }
        //         // else
        //         // {
        //         //     Console.WriteLine("empty");
        //         // }

        //         var pr = new Product()
        //         {
        //             PR_ID = ID,
        //             NAME = NAME
        //         };
        //         // // Gắn pr vào context để theo dõi, nó trả vể đối tượng EntityEntry<Product>
        //         // EntityEntry<Product> pr_e = dbContext.Attach(pr);

        //         // // Lấy thuộc tính Name của Product và thiết lập nó cần cập nhật
        //         // // với IsModified  = true;
        //         // pr_e.Property(p => p.NAME).IsModified = true;

        //         // await dbContext.SaveChangesAsync();


        //         // bỏ qua sự giám sát k cập nhât
        //         // EntityEntry<Product> eProduct = dbContext.Entry(pr);
        //         // eProduct.State = EntityState.Detached;



        //         // // dbContext.products.Update(pr);
        //         // await dbContext.SaveChangesAsync();
        //     }
        // }
        // public static async Task DeleteProductBy(int ID)
        // {
        //     using (var dbContext = new ProductContext())
        //     {
        //         var products = await (from p in dbContext.products
        //                               where p.PR_ID == ID
        //                               select p).FirstOrDefaultAsync();
        //         if (products != null)
        //         {
        //             dbContext.Remove(products);
        //             await dbContext.SaveChangesAsync();
        //         }
        //     }
        // }
        public static async Task Main(string[] args)
        {
            // await CreateDatabase();
            // await InsertProduct();
            // await FindAllProduct();
            // await UpdateProductById(1, "J7 PRIME extra");
            // await DeleteProductBy(1);


            // past 2 

            // ShopContext context = new ShopContext();
            // await context.DeleteDatabase();
            // await context.CreateDatabase();

            // await CommonService.InsertData();
            // await CommonService.FindAll();

            // await CommonService.FindAllById(3);
            // await CommonService.UpdateData(3);
            // await CommonService.findAllJoin();
            await CommonService.RawQuery();


            // await CategoryService.InsertData();
        }
    }
}

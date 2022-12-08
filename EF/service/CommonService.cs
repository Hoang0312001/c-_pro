using EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EF.service
{
    public class CommonService
    {
        public CommonService()
        {
        }

        public static async Task FindAll()
        {
            using (var dbContext = new ShopContext())
            {
                var products = await dbContext.products.ToListAsync();
                foreach (var p in products)
                {
                    Console.WriteLine(p);
                }
            }
        }

        public static async Task FindAllById(int Id)
        {
            using (var dbContext = new ShopContext())
            {
                var products = await dbContext.products.FindAsync(Id);

                Console.WriteLine(products.NAME);

            }
        }
        // public static async Task InsertData()
        // {
        //     using (var dbContext = new ShopContext())
        //     {

        //         await dbContext.products.AddAsync(new Product
        //         {
        //             NAME = "San pham 1",
        //             Provider = "SAM SUNG",
        //             Price = 1020

        //         });

        //         await dbContext.products.AddAsync(new Product
        //         {
        //             NAME = "San pham 2",
        //             Provider = "Apple",
        //             Price = 15000

        //         });


        //         await dbContext.products.AddAsync(new Product
        //         {
        //             NAME = "San pham 3",
        //             Provider = "Apple",
        //             Price = 10040

        //         });

        //         await dbContext.SaveChangesAsync();


        //     }
        // }

        public static async Task UpdateData(int Id)
        {
            using (var dbContext = new ShopContext())
            {
                var product = await (from p in dbContext.products
                                     where p.Id == Id
                                     select p).FirstOrDefaultAsync();

                var category = await (from p in dbContext.categories
                                      where p.Id == Id
                                      select p).FirstOrDefaultAsync();
                if (product != null)
                {
                    product.category = category;
                }
                await dbContext.SaveChangesAsync();

            }
        }

        public static async Task findAllJoin()
        {
            using (var dbContext = new ShopContext())
            {
                var product = from p in dbContext.products
                              join c in dbContext.categories on p.category.Id equals c.Id
                              select new
                              {
                                  name = p.NAME,
                                  loai = c.NAME
                              };
                foreach (var p in product)
                {
                    Console.WriteLine($"{p.name}-{p.loai}");
                }


            }
        }

        public static async Task RawQuery()
        {
            using (var context = new ShopContext())
            {
                String sql = "select * from Product order by Price Desc";
                var products = context.products.FromSqlRaw(sql);

                await products.ForEachAsync(p =>
                {
                    Console.WriteLine(p.NAME);
                });
            }
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.Entity;

namespace EF.service
{
    public class CategoryService
    {
        public static async Task InsertData()
        {
            using (var dbContext = new ShopContext())
            {

                await dbContext.categories.AddAsync(new Category
                {
                    NAME = "Laptop",

                    Description = "Hang chat luong 5 sao"

                });

                await dbContext.categories.AddAsync(new Category
                {
                    NAME = "Phone",

                    Description = "Hang chat luong 5 sao"

                });


                await dbContext.categories.AddAsync(new Category
                {
                    NAME = "table",

                    Description = "Hang chat luong 5 sao"

                });

                await dbContext.SaveChangesAsync();


            }
        }
    }
}
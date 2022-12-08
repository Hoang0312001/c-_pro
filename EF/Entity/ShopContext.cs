using EF.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EF
{
    class ShopContext : DbContext, IDisposable
    {
        public DbSet<Product> products { set; get; }
        public DbSet<Category> categories { set; get; }




        //     // hien thi cau query
        //     public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        //     {
        //         builder
        //                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Warning)
        //                .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Debug)
        //                .AddConsole();
        //     }
        // );
        private const string connectionString = @"
                Data Source=localhost,1433;Initial Catalog=SHOP;User ID=sa;Password=1234 ; TrustServerCertificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            optionsBuilder.UseSqlServer(connectionString)
            .UseLoggerFactory(loggerFactory);
        }
        public async Task CreateDatabase()
        {
            String databasename = Database.GetDbConnection().Database;
            Console.WriteLine("Create database : " + databasename);
            bool result = await Database.EnsureCreatedAsync();
            string resultString = result ? "Database created success" : "Database fail";
            Console.WriteLine($"{databasename} {resultString}");


        }
        public async Task DeleteDatabase()
        {
            String databasename = Database.GetDbConnection().Database;
            Console.WriteLine("you want to delete database: " + databasename);
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                bool result = await Database.EnsureDeletedAsync();
                string resultString = result ? "Database delete success" : "Database delete fail";
                Console.WriteLine($"{databasename} {resultString}");


            }
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
                // entity.ToTable("Product");

                entity.Property(e => e.Id)
                .UseIdentityColumn(1, 1);

                entity.Property(e => e.NAME)
                .HasColumnName("ProductName")
                .HasColumnType("nvarchar(500)")
                .HasDefaultValue("không có");

                entity.Property(e => e.Provider)
                              .HasColumnName("Provider")
                              .HasColumnType("nvarchar(500)")
                              .HasDefaultValue("không có");

                entity.Property(e => e.Price)
                .HasColumnType("Money")
                .HasDefaultValue(0);


                entity.HasKey(e => e.Id); // thiet lap key 
                entity.HasIndex(p => p.NAME).IsUnique(true); // thiet lap index 
                // thiet lap moi quan he 1 - 1 
                entity.HasOne(e => e.category)
                .WithMany(category => category.listProduct)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_product_category");

            });
        }

    }
}
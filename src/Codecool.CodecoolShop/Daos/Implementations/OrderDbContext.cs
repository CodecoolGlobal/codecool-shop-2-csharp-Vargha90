using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext(DbContextOptions<OrderDBContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
    }

    public class DataGenerator
    {
        //public static void Initialize(IServiceProvider serviceProvider)
        //{
        //    using (var context = new OrderDBContext(
        //        serviceProvider.GetRequiredService<DbContextOptions<OrderDBContext>>()))
        //    {
        //        // Look for any board games.
        //        if (context.Products.Any())
        //        {
        //            return;   // Data was already seeded
        //        }

        //        context.Products.AddRange(
        //            new Models.Product
        //            {
        //                Currency = "forint",
        //                DefaultPrice = 100,
        //                ProductCategory = new Models.ProductCategory { Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." },
        //                Supplier = new Models.Supplier { Name = "Lenovo", Description = "Computers" }
        //            },
        //            new Models.Product
        //            {
        //                Currency = "forint",
        //                DefaultPrice = 200,
        //                ProductCategory = new Models.ProductCategory { Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." },
        //                Supplier = new Models.Supplier { Name = "Lenovo", Description = "Computers" }
        //            },
        //            new Models.Product
        //            {
        //                Currency = "forint",
        //                DefaultPrice = 300,
        //                ProductCategory = new Models.ProductCategory { Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." },
        //                Supplier = new Models.Supplier { Name = "Lenovo", Description = "Computers" }
        //            },
        //            new Models.Product
        //            {
        //                Currency = "forint",
        //                DefaultPrice = 400,
        //                ProductCategory = new Models.ProductCategory { Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." },
        //                Supplier = new Models.Supplier { Name = "Lenovo", Description = "Computers" }
        //            },
        //            new Models.Product
        //            {
        //                Currency = "forint",
        //                DefaultPrice = 500,
        //                ProductCategory = new Models.ProductCategory { Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." },
        //                Supplier = new Models.Supplier { Name = "Lenovo", Description = "Computers" }
        //            },
        //            new Models.Product
        //            {
        //                Currency = "forint",
        //                DefaultPrice = 600,
        //                ProductCategory = new Models.ProductCategory { Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." },
        //                Supplier = new Models.Supplier { Name = "Lenovo", Description = "Computers" }
        //            }); ;

        //        context.SaveChanges();
        //    }
        //}
    }



}

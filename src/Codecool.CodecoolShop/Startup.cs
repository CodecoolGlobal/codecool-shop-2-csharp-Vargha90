using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Codecool.CodecoolShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<IOrderRepository, OrderDbRepository>();
            services.AddDbContext<OrderDBContext>(options => options.UseInMemoryDatabase(databaseName: "Products"));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Product/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });

            SetupInMemoryDatabases();
        }

        private void SetupInMemoryDatabases()
        {
            IProductDao productDataStore = ProductDaoMemory.GetInstance();
            IProductCategoryDao productCategoryDataStore = ProductCategoryDaoMemory.GetInstance();
            ISupplierDao supplierDataStore = SupplierDaoMemory.GetInstance();

            Supplier uac = new Supplier{Name = "UAC", Description = "The number 1 megacorporation"};
            supplierDataStore.Add(uac);
            Supplier kalashnikov = new Supplier{Name = "Kalashnikov", Description = "Russian engineering at its best"};
            supplierDataStore.Add(kalashnikov);
            Supplier blackMarket = new Supplier {Name = "Black Market", Description = "No questions asked"};
            supplierDataStore.Add(blackMarket);
            Supplier colt = new Supplier { Name = "Colt", Description = "America... fuck yeah!" };
            supplierDataStore.Add(colt);
            ProductCategory futuristic = new ProductCategory {Name = "Futuristic", Department = "Gun", Description = "Cutting edge technology"};
            ProductCategory ar = new ProductCategory { Name = "Assault Rifle", Department = "Gun", Description = "Cutting edge technology" };
            ProductCategory flamethrower = new ProductCategory { Name = "Not Geneva Compatible", Department = "Banned", Description = "Fun, but maybe not for everyone" };
            ProductCategory bomb = new ProductCategory { Name = "Bomb", Department = "Explosives", Description = "For explosive finishes" };
            ProductCategory handgun = new ProductCategory {Name = "Handgun", Department = "Gun", Description = "Travelers favourite"};
            productCategoryDataStore.Add(futuristic);
            productCategoryDataStore.Add(ar);
            productCategoryDataStore.Add(flamethrower);
            productCategoryDataStore.Add(bomb);
            productCategoryDataStore.Add(handgun);
            productDataStore.Add(new Product { Name = "BFG", DefaultPrice = 666000.0m, Currency = "USD", Description = "Clears your view of anything and everything.", ProductCategory = futuristic, Supplier = uac });
            productDataStore.Add(new Product { Name = "AK 47", DefaultPrice = 52999.0m, Currency = "USD", Description = "For those old-school guys who just love classics.", ProductCategory = ar, Supplier = kalashnikov });
            productDataStore.Add(new Product { Name = "Sea Mine", DefaultPrice = 74999.0m, Currency = "USD", Description = "Calm your seas to calm your soul", ProductCategory = bomb, Supplier = blackMarket });
            productDataStore.Add(new Product { Name = "Tactical Nuke", DefaultPrice = 10000000000.0m, Currency = "USD", Description = "Try throwing it from very far away. Launcher sold separately", ProductCategory = bomb, Supplier = blackMarket });
            productDataStore.Add(new Product { Name = "Flamethrower", DefaultPrice = 120000.0m, Currency = "USD", Description = "Light up the room with your new gear. Gasoline sold separately.", ProductCategory = flamethrower, Supplier = blackMarket });
            productDataStore.Add(new Product { Name = "Colt Python", DefaultPrice = 82000.0m, Currency = "USD", Description = "For everything above C-level", ProductCategory = handgun, Supplier = colt });


        }

    }
}

using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //1. Get the IWebHost which will host this application.
            //IWebHost host = Host.CreateWebHostBuilder(args).Build();

            ////2. Find the service layer within our scope.
            //using (var scope = host.Services.CreateScope())
            //{
            //    //3. Get the instance of BoardGamesDBContext in our services layer
            //    var services = scope.ServiceProvider;
            //    var context = services.GetRequiredService<OrderDBContext>();

            //    //4. Call the DataGenerator to create sample data
            //    DataGenerator.Initialize(services);
            //}

            ////Continue to run the application
            //host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


    }
}

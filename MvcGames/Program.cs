using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MvcGames.Data;
using MvcGames.Models;
using MvcMovie;

namespace MvcGames
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //CreateHostBuilder(args).Build().Run();
            //Create a genric host and builds the app
            var host = CreateHostBuilder(args).Build();

            //Creates scope
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    SeedData.Initialize(services);//seed the Db with the Static method
                }
                catch (Exception ex)
                {
                    //log if an exception occurs
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An exception happened in the seeding of DB.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

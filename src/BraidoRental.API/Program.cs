using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using BraidoRental.API.Infrastructure;
using BraidoRental.Services.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BraidoRental.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ASP.NET Core 3.0+:
            // The UseServiceProviderFactory call attaches the
            // Autofac provider to the generic hosting mechanism.
            var host = Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webHostBuilder =>
                {
                    webHostBuilder
                      .UseContentRoot(Directory.GetCurrentDirectory())
                      .UseIISIntegration()
                      .UseStartup<Startup>();
                })
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<BraidoRentalContext>();

                context.Database.Migrate();

                new BraidoRentalContextSeed()
                   .SeedAsync(context)
                   .Wait();
            }

            host.Run();
        }
    }
}

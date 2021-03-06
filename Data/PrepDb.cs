using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatfromService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatfromService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app) 
        {
            using (var serviceScope = app.ApplicationServices.CreateScope()) 
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());    
            }            
        }

        private static void SeedData(AppDbContext context) 
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");

                context.Platforms.AddRange(
                    new Platform() {Name="Dot Net", Publisher="Microsoft", Cost="Free" },
                    new Platform() { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kuberbates", Publisher = "Microsoft", Cost = "Free" }
                );

                context.SaveChanges();
            }
            else {
                 
                Console.WriteLine("--> We already have Data");
            }
        }
    }
}

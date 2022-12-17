using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var servicScope = app.ApplicationServices.CreateScope())
            {
                SeedData(servicScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(
                    new Platform() {Name="Dot Net", Publisher="Microsoft", Cost="Free" },
                    new Platform() {Name="SQL Sever Express", Publisher="Microsoft", Cost="Free" },
                    new Platform() {Name="Kubernetes", Publisher="Cloud Native Computing Foundation", Cost="Free" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
using ConsoleApp.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace ConsoleApp.Settings
{
    public static class Setting
    {
        public static string GetConnectionString()
        {
            return "Server=host.docker.internal,1430;User ID=sa;Password=admin1234@;Database=ConsoleDb;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=True;MultipleActiveResultSets=True";

        }



        public static ServiceProvider GetServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
         .AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(Setting.GetConnectionString()))
         .BuildServiceProvider();

            return serviceProvider;
        }
    }
}

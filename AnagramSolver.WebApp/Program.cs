using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using AnagramSolver.DAL;
using AnagramSolver.Models;

namespace AnagramSolver.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            using (var db = new AnagramContext())
            {
                // var query = from b in db.WordEntities orderby b.Word select b;
                // Console.WriteLine("All blogs in the database:");
                // foreach (var item in query)
                // {
                //     Console.WriteLine(item.Word);
                // }
                // var word = new WordEntity { Word = "test" };
                // db.WordEntities.Add(word);
                db.SaveChanges();
            }

            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

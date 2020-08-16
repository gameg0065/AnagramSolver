using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using AnagramSolver.BusinessLogic;
using AnagramSolver.Contracts;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using AnagramSolver.DAL;
using AnagramSolver.Models;

namespace AnagramSolver.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnagramController : ControllerBase
    {

        private readonly ILogger<AnagramController> _logger;
        private readonly IConfiguration Configuration;

        public AnagramController(ILogger<AnagramController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<string>>> Get(string id, [FromQuery] int numberOfAnagramsToGenerate)
        {
            // using (var db = new AnagramContext(Configuration["ConnectionString"]))
            // {
            //     var query = from b in db.WordEntities orderby b.Word select b;
            //     Console.WriteLine("All blogs in the database:");
            //     foreach (var item in query)
            //     {
            //         Console.WriteLine(item.Word);
            //     }
            //     // var word = new WordEntity { Word = "test" };
            //     // db.WordEntities.Add(word);
            //     db.SaveChanges();
            // }
            if(numberOfAnagramsToGenerate == 0) {
                numberOfAnagramsToGenerate = 1;
            }
            var anagramGenerator = new AnagramGenerator();
            var dataBase = new DataBase();
            DataBase.connectionString = Configuration["ConnectionString"];
            var items = anagramGenerator.GenerateAnagrams(id, numberOfAnagramsToGenerate);
            dataBase.SaveUserLog( HttpContext.Connection.RemoteIpAddress.ToString() , id, items);    
        
            if (items.Count < 1)
            {
                return NotFound();
            }
            
            return items;
        }
    }
}
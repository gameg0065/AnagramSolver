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

namespace AnagramSolver.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnagramController : ControllerBase
    {

        private readonly ILogger<AnagramController> _logger;
        private readonly IConfiguration Configuration;

        public AnagramController(ILogger<AnagramController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAnagrams()
        {
            var dictionaryManager = new DictionaryManager();
            var anagramGenerator = new AnagramGenerator();
            // dictionaryManager.LoadDictionary(Configuration["DictionaryPath"]);
            var todoItems = anagramGenerator.GenerateAnagrams("alus", 1);
            var query = from item in todoItems select item;
            Console.WriteLine("test");

            if (todoItems.Count < 1)
            {
                return NotFound();
            }

            return await query.AsQueryable().ToListAsync();
        }
    }
}

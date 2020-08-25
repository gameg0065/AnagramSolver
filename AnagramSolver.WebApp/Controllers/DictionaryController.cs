using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using AnagramSolver.Contracts;
using AnagramSolver.DAL;

namespace AnagramSolver.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DictionaryController : ControllerBase
    {

        private readonly ILogger<DictionaryController> _logger;
        private readonly IConfiguration Configuration;

        public DictionaryController(ILogger<DictionaryController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        [HttpGet("{index}")]
        public async Task<ActionResult<Dictionary<string, DictionaryEntry>>> Get(int index)
        {
            var dataBase = new CodeFirstDataBase();
            var numberOfItemsToReturn = Int32.Parse(Configuration["NumberOfDictionaryEntriesToReturn"]);
            var items = await dataBase.GetWords(index, numberOfItemsToReturn, Configuration["ConnectionString"]);

            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }

        [HttpGet("filter/{word}")]
        public async Task<ActionResult<Dictionary<string, DictionaryEntry>>> GetFilteredWord(string word)
        {
            var dataBase = new CodeFirstDataBase();
            var items = await dataBase.FilterWords(word, Configuration["ConnectionString"]);

            if (items.Count < 1)
            {
                return NotFound();
            }
            
            return items;
        }
        
        [HttpGet("download")]
        public async Task<IActionResult> Download()
        {
            var filePath = Configuration["DictionaryPath"];
            _logger.LogInformation($"downloading file [{filePath}].");
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, "text/plain; charset=us-ascii", "zodynas");
        }
    }
}

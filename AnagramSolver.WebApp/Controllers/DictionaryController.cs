using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using AnagramSolver.BusinessLogic;
using AnagramSolver.Contracts;
using System.Data.Entity;
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

        [HttpGet]
        public async Task<ActionResult<Dictionary<string, DictionaryEntry>>> Get()
        {
            var dictionaryManager = new DictionaryManager();
            var items = dictionaryManager.LoadDictionary(Configuration["DictionaryPath"]);

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
            var items = dataBase.FilterWords(word, Configuration["ConnectionString"]);

            if (items.Count < 1)
            {
                return NotFound();
            }
            
            return items;
        }
        [HttpGet("{index}")]
        public async Task<ActionResult<Dictionary<string, DictionaryEntry>>> Get(int index)
        {
            var dictionaryManager = new DictionaryManager();
            var from = Int32.Parse(Configuration["NumberOfDictionaryEntriesToReturn"]) * (index - 1);
            var to = Int32.Parse(Configuration["NumberOfDictionaryEntriesToReturn"]) * index;
            var items = dictionaryManager.LoadDictionary(Configuration["DictionaryPath"])
            .Take(to)
            .Skip(from)
            .ToDictionary(c => c.Key, c => c.Value);

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
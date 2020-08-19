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
            if(numberOfAnagramsToGenerate == 0) {
                numberOfAnagramsToGenerate = 1;
            }
            
            var anagramGenerator = new AnagramGenerator();
            var items = anagramGenerator.GenerateAnagrams(id, numberOfAnagramsToGenerate, Configuration["ConnectionString"]);
        
            if (items.Count < 1)
            {
                return NotFound();
            }

            var codeFirstDataBase = new CodeFirstDataBase();
            codeFirstDataBase.SaveUserLog( HttpContext.Connection.RemoteIpAddress.ToString(), id, Configuration["ConnectionString"]);    
            
            return items;
        }
    }
}
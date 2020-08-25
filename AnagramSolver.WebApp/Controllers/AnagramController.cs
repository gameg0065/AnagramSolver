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
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace AnagramSolver.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnagramController : ControllerBase
    {

        private readonly ILogger<AnagramController> _logger;
        private readonly IConfiguration Configuration;
        static readonly HttpClient client = new HttpClient();

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
            var items = await anagramGenerator.GenerateAnagrams(id, numberOfAnagramsToGenerate, Configuration["ConnectionString"]);
        
            if (items.Count < 1)
            {
                return NotFound();
            }

            var codeFirstDataBase = new CodeFirstDataBase();
            codeFirstDataBase.SaveUserLog( HttpContext.Connection.RemoteIpAddress.ToString(), id, Configuration["ConnectionString"]);    
            
            return items;
        }

        [HttpGet("anagramica/{id}")]
        public async Task<ActionResult<List<string>>> GetAnagramsFromAnagramica(string id)
        {
            const string URL = "http://www.anagramica.com/all/";
            var items = new List<string>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(id).Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var jsonString = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<RootJsonObject>(jsonString).All;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }
    }
}
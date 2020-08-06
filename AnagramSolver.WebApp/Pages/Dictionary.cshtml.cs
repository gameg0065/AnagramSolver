using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using AnagramSolver.BusinessLogic;
using AnagramSolver.Contracts;
using System.Net.Http;
using Newtonsoft.Json;

namespace AnagramSolver.WebApp.Pages
{
    public class DictionaryModel : PageModel
    {
        private readonly ILogger<DictionaryModel> _logger;
        static readonly HttpClient client = new HttpClient();
        public Dictionary<string, DictionaryEntry> Dictionary { get; private set; } = new Dictionary<string, DictionaryEntry>();
        public int Id { get; set; } = 1;

        public DictionaryModel(ILogger<DictionaryModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync(int id) {
            if(id > 0 ) {
                Id = id;
            }
            await GetDictionary(Id);
        }
        private async Task GetDictionary(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Dictionary/" + id);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                Dictionary = JsonConvert.DeserializeObject<Dictionary<string, DictionaryEntry>>(jsonString);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
        public int Next(string next, int id)
        {
            if(next == "True") {
                id++;
            } else if(id > 1) {
                id--;
            }
            return id;
        }
    }
}

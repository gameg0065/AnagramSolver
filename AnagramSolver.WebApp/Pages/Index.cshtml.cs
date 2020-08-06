using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using AnagramSolver.BusinessLogic;
using System.Net.Http;
using Newtonsoft.Json;

namespace AnagramSolver.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        static readonly HttpClient client = new HttpClient();
        public List<string> Anagrams { get; private set; } = new List<string>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public async Task OnGetAsync(string id)
        {
            await FindAnagrams(id);
        }
        private async Task FindAnagrams(string word)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Anagram/" + word);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                Anagrams = JsonConvert.DeserializeObject<List<string>>(jsonString);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}

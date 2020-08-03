using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using AnagramSolver.BusinessLogic;
using Microsoft.Extensions.Configuration;

namespace AnagramSolver.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration Configuration;
        public List<string> Anagrams { get; private set; } = new List<string>();

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public void OnGet(string id)
        {
            Anagrams = FindAnagrams(id);
        }
        private List<string> FindAnagrams(string word) {
            var dictionaryManager = new DictionaryManager();
            var anagramGenerator = new AnagramGenerator();
            dictionaryManager.LoadDictionary(Configuration["DictionaryPath"]);
            return anagramGenerator.GenerateAnagrams(word, 1);
        }
    }
}

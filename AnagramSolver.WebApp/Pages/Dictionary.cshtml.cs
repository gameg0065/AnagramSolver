using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using AnagramSolver.BusinessLogic;
using AnagramSolver.Contracts;

namespace AnagramSolver.WebApp.Pages
{
    public class DictionaryModel : PageModel
    {
        private readonly ILogger<DictionaryModel> _logger;
        private readonly IConfiguration Configuration;
        public Dictionary<string, DictionaryEntry> Dictionary { get; private set; } = new Dictionary<string, DictionaryEntry>();
        public int Id { get; set; } = 1;
        public readonly int NumberOfItemsToDislay = 100;

        public DictionaryModel(ILogger<DictionaryModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public void OnGet(int id) {
            if(id > 0 ) {
                Id = id;
            }
            Dictionary = GetDictionary(Configuration["DictionaryPath"]);
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
        private Dictionary<string, DictionaryEntry> GetDictionary(string path) {
            var dictionaryManager = new DictionaryManager();
            return dictionaryManager.LoadDictionary(Configuration["DictionaryPath"]);
        }
    }
}

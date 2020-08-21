using System.Collections.Generic;
using Newtonsoft.Json;

namespace AnagramSolver.Contracts
{
    public class RootJsonObject
    {
        [JsonProperty("all")]
        public List<string> All { get; set; }
    }
}

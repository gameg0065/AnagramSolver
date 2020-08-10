using System;
using System.Collections.Generic;

namespace AnagramSolver.EF.DatabaseFirst.Models
{
    public partial class CachedWord
    {
        public string SearchWord { get; set; }
        public int AnagramId { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AnagramSolver.EF.DatabaseFirst.Models
{
    public partial class UserLog
    {
        public string UserIp { get; set; }
        public DateTime SearchTime { get; set; }
        public string SearchWord { get; set; }
        public string Anagram { get; set; }
    }
}

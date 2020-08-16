using System;
using System.Collections.Generic;

namespace AnagramSolver.Models
{
    public class CachedWordEntity
    {
        public int ID { get; set; }
        public string SearchWord { get; set; }
        public virtual ICollection<WordEntity> WordEntity { get; set; }
    }
}
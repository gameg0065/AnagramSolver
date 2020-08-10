using System;
using System.Collections.Generic;

namespace AnagramSolver.Models
{
    public class UserLogEntity
    {
        public int ID { get; set; }
        public string UserIP { get; set; }
        public DateTime LogDate { get; set; }
        public virtual ICollection<CachedWordEntity> CachedWordEntity { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnagramSolver.Models
{
    public class UserLogEntity
    {
        
        [Key]
        [Index(IsUnique = true)]
        public int UserLogId { get; set; }
        public string UserIP { get; set; }
        public DateTime LogDate { get; set; }
        public virtual CachedWordEntity CachedWordEntity { get; set; }
    }
}
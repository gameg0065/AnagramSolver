using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnagramSolver.Models
{
    public class CachedWordEntity
    {
        [Key]
        [Index(IsUnique = true)]
        public int Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public string SearchWord { get; set; }
        public virtual ICollection<WordEntity> WordEntity { get; set; }
    }
}
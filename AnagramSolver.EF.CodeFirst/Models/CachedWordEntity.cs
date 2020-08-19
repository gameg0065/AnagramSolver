using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnagramSolver.Models
{
    public class CachedWordEntity
    {
        public CachedWordEntity()
        {
            WordEntities = new HashSet<WordEntity>();
        }
        
        [Key]
        [Index(IsUnique = true)]
        public int CachedWordId { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public string SearchWord { get; set; }

        public virtual ICollection<WordEntity> WordEntities { get; set; }
    }
}
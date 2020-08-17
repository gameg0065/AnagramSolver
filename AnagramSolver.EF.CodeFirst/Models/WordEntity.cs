using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnagramSolver.Models
{
    public class WordEntity
    {
        [Key]
        [Index(IsUnique = true)]
        public int Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public string Word { get; set; }
        public string Category { get; set; }
    }
}
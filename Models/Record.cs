using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Manirajan.Models
{
    public class Record
    {
        [Key]
        public int MovieId { get; set; }


        // Syntax that sets up the foreign key relationship to the other table.
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        public string Director { get; set; }

        public string Rating { get; set; }

        [Required]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required]
        public string CopiedToPlex { get; set; }

        public string? Notes { get; set; }

    }
}

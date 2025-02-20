using Mission06_Manirajan.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Record
{
    [Key]
    public int MovieId { get; set; }

    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;  // Ensures Title is always non-null

    [Required]
    public int Year { get; set; }

    public string? Director { get; set; }  // Nullable

    public string? Rating { get; set; }  // Nullable

    [Required]
    public bool Edited { get; set; }

    public string? LentTo { get; set; }

    [Required]
    public string CopiedToPlex { get; set; } = "No";  // Default value

    public string? Notes { get; set; }
}

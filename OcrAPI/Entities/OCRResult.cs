using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcrAPI.Entities;

public class OCRResult
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string ImageUrl { get; set; }
    
    public string ExtractedText { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
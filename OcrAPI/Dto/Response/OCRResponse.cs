namespace OcrAPI.Dto.Response;

public class OCRResponse
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public string ExtractedText { get; set; }
    public DateTime CreatedAt { get; set; } 
}
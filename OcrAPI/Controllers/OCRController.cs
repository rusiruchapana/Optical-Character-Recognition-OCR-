using Microsoft.AspNetCore.Mvc;
using OcrAPI.Services;

namespace OcrAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OCRController: ControllerBase
{
    private readonly OCRService _ocrService;

    public OCRController(OCRService ocrService)
    {
        _ocrService = ocrService;
    }

    [HttpPost("upload-image")]
    public IActionResult UploadImage(IFormFile file)
    {
        if (file==null || file.Length==0)
        {
            return BadRequest("No file uploaded");
        }

        var filePath = Path.Combine("UploadedImages" , file.FileName );
        Directory.CreateDirectory("UploadedImages");
        
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        var extractedText = _ocrService.ExtractTextFromImage(filePath); 
        

        return Ok(new {Text = extractedText});
    }
}
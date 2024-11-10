using Microsoft.AspNetCore.Mvc;
using OpenCvSharp;
using Tesseract;

namespace OcrAPI.Services;


public class OCRService{
    
    private string _tesseractPath = @"C:\Program Files\Tesseract-OCR\tessdata";
    
    public string ExtractTextFromImage(string filePath)
    {
        // Preprocess the image using OpenCV
        Mat opencvImage = Cv2.ImRead(filePath);
        Cv2.CvtColor(opencvImage, opencvImage, ColorConversionCodes.BGR2GRAY);
        Cv2.Threshold(opencvImage, opencvImage, 0, 255, ThresholdTypes.BinaryInv | ThresholdTypes.Otsu);

        // Save the preprocessed image to a temporary location
        string tempPath = Path.Combine(Path.GetTempPath(), "processed_image.png");
        Cv2.ImWrite(tempPath, opencvImage);

        // Use Tesseract to extract text from the processed image
        using (var engine = new TesseractEngine(_tesseractPath, "eng", EngineMode.Default))
        {
            using (var tesseractImage = Pix.LoadFromFile(tempPath))
            {
                var result = engine.Process(tesseractImage);
                return result.GetText();
            }
        }
    }
}
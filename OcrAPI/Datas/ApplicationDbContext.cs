using Microsoft.EntityFrameworkCore;
using OcrAPI.Entities;

namespace OcrAPI.Datas;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }
    public DbSet<OCRResult> OCRResults { get; set; }
    
}
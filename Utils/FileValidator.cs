using Microsoft.AspNetCore.Http;
namespace TeamNaGuara.Utils
{
    public static class FileValidator
    {
        private static readonly string[] AllowedExt = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
        public const long MaxBytes = 4 * 1024 * 1024; // 4 MB

        public static (bool ok, string error) Validate(IFormFile file)
        {
            if (file == null) return (true, null);
            if (file.Length == 0) return (false, "El archivo está vacío");
            if (file.Length > MaxBytes) return (false, "El archivo excede el tamaño máximo de 4 MB");
            var ext = System.IO.Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowedExt.Contains(ext)) return (false, "Formato no permitido. Use JPG, PNG o PDF");
            return (true, null);
        }
    }
}

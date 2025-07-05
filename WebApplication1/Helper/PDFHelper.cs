namespace DpeApi.Helper
{
    public static class PDFHelper
    {
        public static async Task<(bool Success, string Message, string FileGUID, string FileName)> SavePdf(IFormFile file, string label, string folderPath)
        {
            if (file == null || file.Length == 0)
                return (false, $"{label} is required.", null, null);

            var ext = Path.GetExtension(file.FileName);
            if (string.IsNullOrEmpty(ext) || ext.ToLower() != ".pdf")
                return (false, $"Only PDF files are allowed for {label}.", null, null);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileGUID = $"{Guid.NewGuid()}.pdf";
            var filePath = Path.Combine(folderPath, fileGUID);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return (true, "Success", fileGUID, file.FileName);
        }
    }
}

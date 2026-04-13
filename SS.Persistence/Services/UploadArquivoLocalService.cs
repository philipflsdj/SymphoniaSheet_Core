using SS.Domain.Contracts.Services;


namespace SS.Persistence.Services
{
    public class UploadArquivoLocalService : IUploadArquivoService
    {
        private readonly string _basePath;

        public UploadArquivoLocalService()
        {
            _basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);
        }

        public async Task<string> UploadAsync(Stream stream, string fileName, string contentType, CancellationToken cancellationToken = default)
        {
            var extension = Path.GetExtension(fileName);
            var newFileName = $"{Guid.NewGuid()}{extension}";
            var fullPath = Path.Combine(_basePath, newFileName);

            await using var fileStream = new FileStream(fullPath, FileMode.Create);
            await stream.CopyToAsync(fileStream, cancellationToken);

            return $"/uploads/{newFileName}";
        }

        public Task<bool> DeleteAsync(string filePath, CancellationToken cancellationToken = default)
        {
            var normalized = filePath.Replace("/", Path.DirectorySeparatorChar.ToString()).TrimStart(Path.DirectorySeparatorChar);
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", normalized);

            if (!File.Exists(fullPath))
                return Task.FromResult(false);

            File.Delete(fullPath);
            return Task.FromResult(true);
        }
    }
}

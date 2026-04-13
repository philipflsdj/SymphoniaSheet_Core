using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Contracts.Services
{
    public interface IUploadArquivoService
    {
        Task<string> UploadAsync(Stream stream, string fileName, string contentType, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(string filePath, CancellationToken cancellationToken = default);
    }
}

using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Models
{
    public class Arquivo : EntityBase
    {
        public string NomeOriginal { get; private set; } = string.Empty;
        public string NomeArmazenado { get; private set; } = string.Empty;
        public string ContentType { get; private set; } = string.Empty;
        public string Extensao { get; private set; } = string.Empty;
        public long TamanhoBytes { get; private set; }
        public string Url { get; private set; } = string.Empty;
        public string? StorageProvider { get; private set; }
        public string? Checksum { get; private set; }

        protected Arquivo() { }

        public Arquivo(
            string nomeOriginal,
            string nomeArmazenado,
            string contentType,
            string extensao,
            long tamanhoBytes,
            string url,
            string? storageProvider,
            string? checksum)
        {
            NomeOriginal = nomeOriginal;
            NomeArmazenado = nomeArmazenado;
            ContentType = contentType;
            Extensao = extensao;
            TamanhoBytes = tamanhoBytes;
            Url = url;
            StorageProvider = storageProvider;
            Checksum = checksum;

            Validar();
        }

        private void Validar()
        {
            ClearNotifications();

            if (string.IsNullOrWhiteSpace(NomeOriginal))
                AddNotification("Nome original do arquivo é obrigatório.");

            if (string.IsNullOrWhiteSpace(Url))
                AddNotification("URL do arquivo é obrigatória.");
        }
    }
}

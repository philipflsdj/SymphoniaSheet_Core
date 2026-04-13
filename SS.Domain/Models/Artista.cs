using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Models
{
    public class Artista : EntityBase
    {
        public string Nome { get; private set; } = string.Empty;
        public string? Descricao { get; private set; }
        public string? ImagemUrl { get; private set; }
        public bool Ativo { get; private set; } = true;

        public virtual ICollection<Partitura> Partituras { get; private set; } = new List<Partitura>();

        protected Artista() { }

        public Artista(string nome, string? descricao, string? imagemUrl)
        {
            Nome = nome;
            Descricao = descricao;
            ImagemUrl = imagemUrl;

            Validar();
        }

        public void Atualizar(string nome, string? descricao, string? imagemUrl)
        {
            Nome = nome;
            Descricao = descricao;
            ImagemUrl = imagemUrl;
            Validar();
        }

        public void Ativar() => Ativo = true;
        public void Inativar() => Ativo = false;

        private void Validar()
        {
            ClearNotifications();

            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification("Nome do artista é obrigatório.");
        }
    }
}

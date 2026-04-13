using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Models
{
    public class Categoria : EntityBase
    {
        public string Nome { get; private set; } = string.Empty;
        public string? Descricao { get; private set; }
        public string? Icone { get; private set; }
        public bool Ativa { get; private set; } = true;
        public int OrdemExibicao { get; private set; }

        public virtual ICollection<Partitura> Partituras { get; private set; } = new List<Partitura>();

        protected Categoria() { }

        public Categoria(string nome, string? descricao, string? icone, int ordemExibicao = 0)
        {
            Nome = nome;
            Descricao = descricao;
            Icone = icone;
            OrdemExibicao = ordemExibicao;

            Validar();
        }

        public void Atualizar(string nome, string? descricao, string? icone, int ordemExibicao)
        {
            Nome = nome;
            Descricao = descricao;
            Icone = icone;
            OrdemExibicao = ordemExibicao;

            Validar();
        }

        public void Ativar() => Ativa = true;
        public void Inativar() => Ativa = false;

        private void Validar()
        {
            ClearNotifications();

            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification("Nome da categoria é obrigatório.");
        }
    }
}

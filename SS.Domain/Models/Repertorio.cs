using SS.Domain.SeedWorks;

namespace SS.Domain.Models
{
    public class Repertorio : EntityBase
    {
        public Guid UsuarioId { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string? Descricao { get; private set; }

        public virtual Usuario? Usuario { get; private set; }
        public virtual ICollection<RepertorioItem> Itens { get; private set; } = new List<RepertorioItem>();

        protected Repertorio() { }

        public Repertorio(Guid usuarioId, string nome, string? descricao)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Descricao = descricao;

            Validar();
        }

        public void Atualizar(string nome, string? descricao)
        {
            Nome = nome;
            Descricao = descricao;
            Validar();
        }

        private void Validar()
        {
            ClearNotifications();

            if (UsuarioId == Guid.Empty)
                AddNotification("Usuário é obrigatório.");

            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification("Nome do repertório é obrigatório.");
        }
    }
}

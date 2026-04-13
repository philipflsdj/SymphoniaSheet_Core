using SS.Domain.Enums;
using SS.Domain.SeedWorks;


namespace SS.Domain.Models
{
    public class Comentario : EntityBase
    {
        public Guid UsuarioId { get; private set; }
        public Guid PartituraId { get; private set; }
        public string Texto { get; private set; } = string.Empty;
        public StatusComentario Status { get; private set; }

        public virtual Usuario? Usuario { get; private set; }
        public virtual Partitura? Partitura { get; private set; }

        protected Comentario() { }

        public Comentario(Guid usuarioId, Guid partituraId, string texto)
        {
            UsuarioId = usuarioId;
            PartituraId = partituraId;
            Texto = texto;
            Status = StatusComentario.Ativo;

            Validar();
        }

        public void AtualizarTexto(string texto)
        {
            Texto = texto;
            Validar();
        }

        public void Ocultar() => Status = StatusComentario.Oculto;
        public void Excluir() => Status = StatusComentario.Excluido;

        private void Validar()
        {
            ClearNotifications();

            if (UsuarioId == Guid.Empty)
                AddNotification("Usuário é obrigatório.");

            if (PartituraId == Guid.Empty)
                AddNotification("Partitura é obrigatória.");

            if (string.IsNullOrWhiteSpace(Texto))
                AddNotification("Texto do comentário é obrigatório.");
        }
    }
}

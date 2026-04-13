using SS.Domain.SeedWorks;

namespace SS.Domain.Models
{
    public class Favorito : EntityBase
    {
        public Guid UsuarioId { get; private set; }
        public Guid PartituraId { get; private set; }

        public virtual Usuario? Usuario { get; private set; }
        public virtual Partitura? Partitura { get; private set; }

        protected Favorito() { }

        public Favorito(Guid usuarioId, Guid partituraId)
        {
            UsuarioId = usuarioId;
            PartituraId = partituraId;

            Validar();
        }

        private void Validar()
        {
            ClearNotifications();

            if (UsuarioId == Guid.Empty)
                AddNotification("Usuário é obrigatório.");

            if (PartituraId == Guid.Empty)
                AddNotification("Partitura é obrigatória.");
        }
    }
}

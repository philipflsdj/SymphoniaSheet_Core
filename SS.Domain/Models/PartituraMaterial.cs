using SS.Domain.Enums;
using SS.Domain.SeedWorks;

namespace SS.Domain.Models
{
    public class PartituraMaterial : EntityBase
    {
        public Guid PartituraId { get; private set; }
        public TipoMaterial TipoMaterial { get; private set; }
        public Guid ArquivoId { get; private set; }
        public int Ordem { get; private set; }

        public virtual Partitura? Partitura { get; private set; }
        public virtual Arquivo? Arquivo { get; private set; }

        protected PartituraMaterial() { }

        public PartituraMaterial(Guid partituraId, TipoMaterial tipoMaterial, Guid arquivoId, int ordem)
        {
            PartituraId = partituraId;
            TipoMaterial = tipoMaterial;
            ArquivoId = arquivoId;
            Ordem = ordem;

            Validar();
        }

        private void Validar()
        {
            ClearNotifications();

            if (PartituraId == Guid.Empty)
                AddNotification("Partitura é obrigatória.");

            if (ArquivoId == Guid.Empty)
                AddNotification("Arquivo é obrigatório.");
        }
    }
}






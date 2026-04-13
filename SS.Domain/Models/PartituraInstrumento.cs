using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Models
{
    public class PartituraInstrumento : EntityBase
    {
        public Guid PartituraId { get; private set; }
        public Guid InstrumentoId { get; private set; }

        public virtual Partitura? Partitura { get; private set; }
        public virtual Instrumento? Instrumento { get; private set; }

        protected PartituraInstrumento() { }

        public PartituraInstrumento(Guid partituraId, Guid instrumentoId)
        {
            PartituraId = partituraId;
            InstrumentoId = instrumentoId;

            Validar();
        }

        private void Validar()
        {
            ClearNotifications();

            if (PartituraId == Guid.Empty)
                AddNotification("Partitura é obrigatória.");

            if (InstrumentoId == Guid.Empty)
                AddNotification("Instrumento é obrigatório.");
        }
    }
}

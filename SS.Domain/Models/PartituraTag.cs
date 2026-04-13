using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Models
{
    public class PartituraTag : EntityBase
    {
        public Guid PartituraId { get; private set; }
        public Guid TagId { get; private set; }

        public virtual Partitura? Partitura { get; private set; }
        public virtual Tag? Tag { get; private set; }

        protected PartituraTag() { }

        public PartituraTag(Guid partituraId, Guid tagId)
        {
            PartituraId = partituraId;
            TagId = tagId;

            Validar();
        }

        private void Validar()
        {
            ClearNotifications();

            if (PartituraId == Guid.Empty)
                AddNotification("Partitura é obrigatória.");

            if (TagId == Guid.Empty)
                AddNotification("Tag é obrigatória.");
        }
    }
}

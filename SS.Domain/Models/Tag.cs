using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Models
{
    public class Tag : EntityBase
    {
        public string Nome { get; private set; } = string.Empty;
        public string Slug { get; private set; } = string.Empty;

        public virtual ICollection<PartituraTag> PartituraTags { get; private set; } = new List<PartituraTag>();

        protected Tag() { }

        public Tag(string nome, string slug)
        {
            Nome = nome;
            Slug = slug;
            Validar();
        }

        private void Validar()
        {
            ClearNotifications();

            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification("Nome da tag é obrigatório.");

            if (string.IsNullOrWhiteSpace(Slug))
                AddNotification("Slug da tag é obrigatório.");
        }
    }
}

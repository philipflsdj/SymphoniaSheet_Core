using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.SeedWorks
{
    public abstract class EntityBase : Entity
    {
        public Guid Id { get; protected set; }

        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        protected EntityBase(Guid id)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
        }
    }
}

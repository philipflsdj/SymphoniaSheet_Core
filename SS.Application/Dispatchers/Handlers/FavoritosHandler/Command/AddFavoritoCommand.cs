using MediatR;
using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.FavoritosHandler.Command
{
    public class AddFavoritoCommand : IRequest<Result>
    {
        public Guid UsuarioId { get; set; }
        public Guid PartituraId { get; set; }
    }
}

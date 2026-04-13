using SS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Contracts.Repositories
{
    public interface IFavoritoRepository
    {
        Task<Favorito?> ObterAsync(Guid usuarioId, Guid partituraId);
        Task<IEnumerable<Favorito>> ObterPorUsuarioAsync(Guid usuarioId);
        Task AdicionarAsync(Favorito favorito);
        Task RemoverAsync(Guid usuarioId, Guid partituraId);
    }
}

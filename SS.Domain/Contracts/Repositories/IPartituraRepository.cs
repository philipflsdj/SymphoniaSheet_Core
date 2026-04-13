using SS.Domain.Arguments;
using SS.Domain.Models;
using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Contracts.Repositories
{
    public interface IPartituraRepository
    {
        Task<Partitura?> ObterPorIdAsync(Guid id);
        Task<PagedResult<Partitura>> BuscarAsync(PartituraFiltro filtro);
        Task<IEnumerable<Partitura>> ObterRecentesAsync(int quantidade);
        Task<IEnumerable<Partitura>> ObterDestaquesAsync(int quantidade);
        Task AdicionarAsync(Partitura partitura);
        Task AtualizarAsync(Partitura partitura);
        Task RemoverAsync(Guid id);
    }
}

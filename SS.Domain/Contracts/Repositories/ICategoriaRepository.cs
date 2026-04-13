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
    public interface ICategoriaRepository
    {
        Task<Categoria?> ObterPorIdAsync(Guid id);
        Task<Categoria?> ObterPorNomeAsync(string nome);
        Task<PagedResult<Categoria>> ObterPaginadoAsync(CategoriaFiltro filtro);
        Task<IEnumerable<Categoria>> ObterAtivasAsync();
        Task AdicionarAsync(Categoria categoria);
        Task AtualizarAsync(Categoria categoria);
        Task RemoverAsync(Guid id);
    }
}

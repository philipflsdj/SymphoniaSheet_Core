using SS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Contracts.Repositories
{
    public interface ITagRepository
    {
        Task<Tag?> ObterPorIdAsync(Guid id);
        Task<Tag?> ObterPorSlugAsync(string slug);
        Task<IEnumerable<Tag>> ObterTodosAsync();
        Task AdicionarAsync(Tag tag);
        Task AtualizarAsync(Tag tag);
        Task RemoverAsync(Guid id);
    }
}

using MediatR;
using SS.Application.Configurations.DTOs.Categoria;
using SS.Domain.Arguments;

namespace SS.Application.Dispatchers.Handlers.CategoriaHandler.Query
{
    public class GetCategoriasPagedQuery : IRequest<CategoriaPagedResultDto>
    {
        public CategoriaFiltro Filtro { get; set; } = new();
    }
}

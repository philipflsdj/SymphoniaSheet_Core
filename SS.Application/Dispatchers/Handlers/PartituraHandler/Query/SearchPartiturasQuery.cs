using MediatR;
using SS.Application.Configurations.DTOs.Partitura;
using SS.Domain.Arguments;
using SS.Domain.SeedWorks;


namespace SS.Application.Dispatchers.Handlers.PartituraHandler.Query
{
    public class SearchPartiturasQuery : IRequest<PagedResult<PartituraListDto>>
    {
        public PartituraFiltro Filtro { get; set; } = new();
    }
}

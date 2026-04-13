using AutoMapper;
using MediatR;
using SS.Application.Configurations.DTOs.Partitura;
using SS.Application.Dispatchers.Handlers.PartituraHandler.Query;
using SS.Domain.Contracts.Repositories;
using SS.Domain.SeedWorks;
namespace SS.Application.Dispatchers.Handlers.PartituraHandler.Handler
{
    public class SearchPartiturasQueryHandler : IRequestHandler<SearchPartiturasQuery, PagedResult<PartituraListDto>>
    {
        private readonly IPartituraRepository _repository;
        private readonly IMapper _mapper;

        public SearchPartiturasQueryHandler(IPartituraRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PartituraListDto>> Handle(SearchPartiturasQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.BuscarAsync(request.Filtro);

            return new PagedResult<PartituraListDto>
            {
                Items = _mapper.Map<IEnumerable<PartituraListDto>>(result.Items),
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                TotalCount = result.TotalCount
            };
        }
    }
}

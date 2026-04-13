using AutoMapper;
using MediatR;
using SS.Application.Configurations.DTOs.Categoria;
using SS.Application.Dispatchers.Handlers.CategoriaHandler.Query;
using SS.Domain.Contracts.Repositories;


namespace SS.Application.Dispatchers.Handlers.CategoriaHandler.Handler
{
    public class GetCategoriasPagedQueryHandler : IRequestHandler<GetCategoriasPagedQuery, CategoriaPagedResultDto>
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoriasPagedQueryHandler(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaPagedResultDto> Handle(GetCategoriasPagedQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.ObterPaginadoAsync(request.Filtro);

            return new CategoriaPagedResultDto
            {
                Items = _mapper.Map<IEnumerable<CategoriaDto>>(result.Items),
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                TotalCount = result.TotalCount,
                TotalPages = result.TotalPages
            };
        }
    }
}

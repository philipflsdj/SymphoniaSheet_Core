using AutoMapper;
using MediatR;
using SS.Application.Configurations.DTOs.Categoria;
using SS.Application.Dispatchers.Handlers.CategoriaHandler.Query;
using SS.Domain.Contracts.Repositories;


namespace SS.Application.Dispatchers.Handlers.CategoriaHandler.Handler
{
    public class GetCategoriaByIdQueryHandler : IRequestHandler<GetCategoriaByIdQuery, CategoriaDto?>
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoriaByIdQueryHandler(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaDto?> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _repository.ObterPorIdAsync(request.Id);
            return categoria is null ? null : _mapper.Map<CategoriaDto>(categoria);
        }
    }
}

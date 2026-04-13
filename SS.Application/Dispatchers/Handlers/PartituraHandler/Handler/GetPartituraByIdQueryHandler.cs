using AutoMapper;
using MediatR;
using SS.Application.Configurations.DTOs.Partitura;
using SS.Application.Dispatchers.Handlers.PartituraHandler.Query;
using SS.Domain.Contracts.Repositories;


namespace SS.Application.Dispatchers.Handlers.PartituraHandler.Handler
{
    public class GetPartituraByIdQueryHandler : IRequestHandler<GetPartituraByIdQuery, PartituraDto?>
    {
        private readonly IPartituraRepository _repository;
        private readonly IMapper _mapper;

        public GetPartituraByIdQueryHandler(IPartituraRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PartituraDto?> Handle(GetPartituraByIdQuery request, CancellationToken cancellationToken)
        {
            var partitura = await _repository.ObterPorIdAsync(request.Id);
            return partitura is null ? null : _mapper.Map<PartituraDto>(partitura);
        }
    }
}

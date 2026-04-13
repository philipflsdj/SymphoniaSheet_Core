using AutoMapper;
using MediatR;
using SS.Application.Configurations.DTOs.Usuario;
using SS.Domain.Contracts.Repositories;

namespace SS.Application.Dispatchers.Handlers.UsuarioHandler.Query
{
    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, UsuarioDto?>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public GetUsuarioByIdQueryHandler(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioDto?> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.ObterPorIdAsync(request.Id);
            return usuario is null ? null : _mapper.Map<UsuarioDto>(usuario);
        }
    }
}

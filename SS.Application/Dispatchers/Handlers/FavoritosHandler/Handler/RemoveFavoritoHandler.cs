using MediatR;
using SS.Application.Dispatchers.Handlers.FavoritosHandler.Command;
using SS.Domain.Contracts.Repositories;
using SS.Domain.SeedWorks;


namespace SS.Application.Dispatchers.Handlers.FavoritosHandler.Handler
{
    public class RemoveFavoritoHandler : IRequestHandler<RemoveFavoritoCommand, Result>
    {
        private readonly IFavoritoRepository _repository;

        public RemoveFavoritoHandler(IFavoritoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(RemoveFavoritoCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoverAsync(request.UsuarioId, request.PartituraId);
            return Result.Ok("Favorito removido com sucesso.");
        }
    }
}

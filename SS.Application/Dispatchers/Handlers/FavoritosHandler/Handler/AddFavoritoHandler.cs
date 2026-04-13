using MediatR;
using SS.Application.Dispatchers.Handlers.FavoritosHandler.Command;
using SS.Domain.Contracts.Repositories;
using SS.Domain.Models;
using SS.Domain.SeedWorks;


namespace SS.Application.Dispatchers.Handlers.FavoritosHandler.Handler
{
    public class AddFavoritoHandler : IRequestHandler<AddFavoritoCommand, Result>
    {
        private readonly IFavoritoRepository _repository;

        public AddFavoritoHandler(IFavoritoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(AddFavoritoCommand request, CancellationToken cancellationToken)
        {
            var existente = await _repository.ObterAsync(request.UsuarioId, request.PartituraId);
            if (existente is not null)
                return Result.Fail("A partitura já foi favoritada.");

            var favorito = new Favorito(request.UsuarioId, request.PartituraId);

            if (!favorito.IsValid)
                return Result.Fail(favorito.Notifications);

            await _repository.AdicionarAsync(favorito);

            return Result.Ok("Favorito adicionado com sucesso.");
        }
    }
}

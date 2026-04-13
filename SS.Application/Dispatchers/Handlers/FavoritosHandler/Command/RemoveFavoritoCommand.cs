using MediatR;
using SS.Domain.SeedWorks;


namespace SS.Application.Dispatchers.Handlers.FavoritosHandler.Command
{
    public class RemoveFavoritoCommand : IRequest<Result>
    {
        public Guid UsuarioId { get; set; }
        public Guid PartituraId { get; set; }
    }
}

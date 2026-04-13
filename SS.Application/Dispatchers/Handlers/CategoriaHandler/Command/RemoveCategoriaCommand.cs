using MediatR;
using SS.Domain.SeedWorks;


namespace SS.Application.Dispatchers.Handlers.CategoriaHandler.Command
{
    public class RemoveCategoriaCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}

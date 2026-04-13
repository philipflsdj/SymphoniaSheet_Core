using MediatR;
using SS.Application.Configurations.DTOs.Categoria;
using SS.Domain.SeedWorks;

namespace SS.Application.Dispatchers.Handlers.CategoriaHandler.Command
{
    public class UpdateCategoriaCommand : IRequest<Result<CategoriaDto>>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public string? Icone { get; set; }
        public int OrdemExibicao { get; set; }
    }
}

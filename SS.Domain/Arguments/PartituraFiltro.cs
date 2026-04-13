using SS.Domain.Enums;

namespace SS.Domain.Arguments
{
    public class PartituraFiltro : PaginacaoFiltro
    {
        public string? Texto { get; set; }
        public Guid? CategoriaId { get; set; }
        public Guid? ArtistaId { get; set; }
        public bool? IsPremium { get; set; }
        public bool? IsVisible { get; set; }
        public StatusPartitura? Status { get; set; }
        public DificuldadePartitura? Dificuldade { get; set; }
    }
}

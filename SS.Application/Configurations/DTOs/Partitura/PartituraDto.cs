using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Configurations.DTOs.Partitura
{
    public class PartituraDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Subtitulo { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid ArtistaId { get; set; }
        public string? Album { get; set; }
        public string? Compositor { get; set; }
        public string? Arranjador { get; set; }
        public string? Tonalidade { get; set; }
        public int? Bpm { get; set; }
        public int Dificuldade { get; set; }
        public string Idioma { get; set; } = "pt-BR";
        public string? Descricao { get; set; }
        public bool IsPremium { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsVisible { get; set; }
        public int Status { get; set; }
        public Guid CriadoPorUsuarioId { get; set; }
    }
}

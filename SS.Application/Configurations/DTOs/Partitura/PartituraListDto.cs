using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Configurations.DTOs.Partitura
{
    public class PartituraListDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Subtitulo { get; set; }
        public bool IsPremium { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsVisible { get; set; }
        public int Status { get; set; }
    }
}

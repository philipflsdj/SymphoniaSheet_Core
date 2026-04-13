using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Configurations.DTOs.Partitura
{   
    public class PartituraMaterialDto
    {
        public Guid ArquivoId { get; set; }
        public int TipoMaterial { get; set; }
        public int Ordem { get; set; }
    }
}

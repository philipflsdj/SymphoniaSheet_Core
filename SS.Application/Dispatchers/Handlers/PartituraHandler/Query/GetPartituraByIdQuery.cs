using MediatR;
using SS.Application.Configurations.DTOs.Partitura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.PartituraHandler.Query
{
    public class GetPartituraByIdQuery : IRequest<PartituraDto?>
    {
        public Guid Id { get; set; }
    }
}

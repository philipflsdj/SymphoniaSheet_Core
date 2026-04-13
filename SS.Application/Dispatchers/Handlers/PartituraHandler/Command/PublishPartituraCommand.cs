using MediatR;
using SS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.PartituraHandler.Command
{
    public class PublishPartituraCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}

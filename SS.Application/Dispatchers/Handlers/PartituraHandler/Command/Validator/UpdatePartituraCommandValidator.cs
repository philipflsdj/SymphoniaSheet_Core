using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.PartituraHandler.Command.Validator
{
    public class UpdatePartituraCommandValidator : AbstractValidator<UpdatePartituraCommand>
    {
        public UpdatePartituraCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Titulo)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.Bpm)
                .GreaterThan(0)
                .When(x => x.Bpm.HasValue);
        }
    }
}

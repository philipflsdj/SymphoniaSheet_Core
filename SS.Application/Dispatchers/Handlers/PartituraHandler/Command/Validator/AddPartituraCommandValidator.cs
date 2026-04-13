using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.PartituraHandler.Command.Validator
{
    public class AddPartituraCommandValidator : AbstractValidator<AddPartituraCommand>
    {
        public AddPartituraCommandValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.CategoriaId)
                .NotEmpty();

            RuleFor(x => x.ArtistaId)
                .NotEmpty();

            RuleFor(x => x.CriadoPorUsuarioId)
                .NotEmpty();

            RuleFor(x => x.Bpm)
                .GreaterThan(0)
                .When(x => x.Bpm.HasValue);
        }
    }
}

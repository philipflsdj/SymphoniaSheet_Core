using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Application.Dispatchers.Handlers.CategoriaHandler.Command.Validator
{
    public class AddCategoriaCommandValidator : AbstractValidator<AddCategoriaCommand>
    {
        public AddCategoriaCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}

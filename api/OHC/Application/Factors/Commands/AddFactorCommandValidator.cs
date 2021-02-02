using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Factors.Commands
{
    public class AddFactorCommandValidator : AbstractValidator<AddFactorCommand>
    {
        public AddFactorCommandValidator()
        {
            RuleFor(f => f.Name).NotEmpty();
        }
    }
}

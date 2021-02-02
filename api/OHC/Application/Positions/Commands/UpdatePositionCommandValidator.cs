using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Positions.Commands
{
    public class UpdatePositionCommandValidator : AbstractValidator<UpdatePositionCommand>
    {
        public UpdatePositionCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}

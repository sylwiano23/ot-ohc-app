using FluentValidation;

namespace Application.Positions.Commands
{
    public class AddPositionCommandValidator : AbstractValidator<AddPositionCommand>
    {
        public AddPositionCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
        }
    }
}

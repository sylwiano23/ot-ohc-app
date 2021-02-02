using FluentValidation;

namespace Application.Factors.Commands
{
    public class UpdateFactorCommandValidator : AbstractValidator<UpdateFactorCommand>
    {
        public UpdateFactorCommandValidator()
        {
            RuleFor(f => f.Id).NotEmpty();
            RuleFor(f => f.Name).NotEmpty();
        }
    }
}

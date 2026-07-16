using FluentValidation;

namespace DCMS.Application.Features.Dentists.Commands.CreateDentist
{
    public class CreateDentistCommandValidator : AbstractValidator<CreateDentistCommand>
    {
        public CreateDentistCommandValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("The field {PropertyName} is required.");

            RuleFor(p => p.Email)
               .NotEmpty().WithMessage("The field {PropertyName} is required.")
               .EmailAddress().WithMessage("The field {PropertyName} must be a valid email address.");
        }
    }
}

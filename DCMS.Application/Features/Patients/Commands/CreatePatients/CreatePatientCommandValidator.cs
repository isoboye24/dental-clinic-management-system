using FluentValidation;

namespace DCMS.Application.Features.Patients.Commands.CreatePatients
{
    public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator() 
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("The field {PropertyName} is required.");

            RuleFor(p => p.Email)
               .NotEmpty().WithMessage("The field {PropertyName} is required.")
               .EmailAddress().WithMessage("The field {PropertyName} must be a valid email address.");
        }
    }
}

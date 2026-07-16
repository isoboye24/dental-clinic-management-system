using FluentValidation;

namespace DCMS.Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("The field {PropertyName} is required.");

            RuleFor(p => p.Email)
               .NotEmpty().WithMessage("The field {PropertyName} is required.")
               .EmailAddress().WithMessage("The field {PropertyName} must be a valid email address.");
        }
    }
}

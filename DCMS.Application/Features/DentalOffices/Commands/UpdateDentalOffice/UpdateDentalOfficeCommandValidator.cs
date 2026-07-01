using FluentValidation;

namespace DCMS.Application.Features.DentalOffices.Commands.UpdateDentalOffice
{
    public class UpdateDentalOfficeCommandValidator : AbstractValidator<UpdateDentalOfficeCommand>
    {
        public UpdateDentalOfficeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}

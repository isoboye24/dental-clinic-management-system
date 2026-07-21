using FluentValidation;

namespace DCMS.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator() 
        {
            RuleFor(x => x.StartDate).GreaterThan(x => x.EndDate).WithMessage("Start time must be earlier than end time.");
        }
    }
}

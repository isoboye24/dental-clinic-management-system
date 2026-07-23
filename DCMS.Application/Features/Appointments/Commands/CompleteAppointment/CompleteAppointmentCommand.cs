using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Appointments.Commands.CompleteAppointment
{
    public class CompleteAppointmentCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}

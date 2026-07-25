using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Appointments.Commands.CancelAppointment
{
    public class CancelAppointmentCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}

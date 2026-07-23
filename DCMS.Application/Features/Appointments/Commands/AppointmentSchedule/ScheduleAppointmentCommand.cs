using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Appointments.Commands.AppointmentSchedule
{
    public class ScheduleAppointmentCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}

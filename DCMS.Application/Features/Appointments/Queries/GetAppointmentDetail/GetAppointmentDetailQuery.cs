using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    public class GetAppointmentDetailQuery : IRequest<AppointmentDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}

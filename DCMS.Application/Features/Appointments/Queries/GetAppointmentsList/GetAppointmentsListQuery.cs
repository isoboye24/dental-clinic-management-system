using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class GetAppointmentsListQuery : AppointmentsFilterDTO, IRequest<List<AppointmentsListDTO>>
    {
    }
}

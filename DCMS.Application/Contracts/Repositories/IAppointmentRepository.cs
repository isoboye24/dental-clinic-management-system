using DCMS.Application.Features.Appointments.Queries.GetAppointmentsList;
using DCMS.Domain.Entities;

namespace DCMS.Application.Contracts.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<bool> OverlapExists(Guid dentistId, DateTime startDate, DateTime endDate);
        new Task<Appointment?> GetById(Guid id);
        Task<IEnumerable<Appointment>> GetFilter(AppointmentsFilterDTO appointmentsFilterDTO);
    }
}

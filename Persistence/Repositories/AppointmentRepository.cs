using DCMS.Application.Contracts.Repositories;
using DCMS.Domain.Entities;
using DCMS.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DCMS.Persistence.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly DCMSDBContext _db;
        public AppointmentRepository(DCMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> OverlapExists(Guid dentistId, DateTime startDate, DateTime endDate)
        {
            return await _db.Appointments.Where(x => x.DentistId == dentistId && x.Status == AppointmentStatus.Scheduled
                && startDate < x.TimeInterval.End && endDate > x.TimeInterval.Start
            ).AnyAsync();
        }

        new public async Task<Appointment?> GetById(Guid id)
        {
            return await _db.Appointments
                .Include(x => x.Dentist)
                .Include(x => x.Patient)
                .Include(x => x.DentalOffice)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

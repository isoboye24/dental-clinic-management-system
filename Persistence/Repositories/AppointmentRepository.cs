using DCMS.Application.Contracts.Repositories;
using DCMS.Domain.Entities;
using DCMS.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using DCMS.Application.Features.Appointments.Queries.GetAppointmentsList;

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

        public async Task<IEnumerable<Appointment>> GetFilter(AppointmentsFilterDTO appointmentsFilterDTO)
        {
            var query = _db.Appointments.AsQueryable();
            if (appointmentsFilterDTO.PatientId.HasValue)
            {
                query = query.Where(x => x.PatientId == appointmentsFilterDTO.PatientId.Value);
            }
            if (appointmentsFilterDTO.DentistId.HasValue)
            {
                query = query.Where(x => x.DentistId == appointmentsFilterDTO.DentistId.Value);
            }
            if (appointmentsFilterDTO.DentalOfficeId.HasValue)
            {
                query = query.Where(x => x.DentalOfficeId == appointmentsFilterDTO.DentalOfficeId.Value);
            }
            query = query.Where(x => x.TimeInterval.Start >= appointmentsFilterDTO.StartDate && x.TimeInterval.End <= appointmentsFilterDTO.EndDate);

            return await query
                .Include(x => x.Dentist)
                .Include(x => x.Patient)
                .Include(x => x.DentalOffice)
                .ToListAsync();
        }
    }
}

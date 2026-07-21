using DCMS.Application.Contracts.Repositories;
using DCMS.Domain.Entities;

namespace DCMS.Persistence.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(DCMSDBContext db) : base(db)
        {
           
        }
    
    }
}

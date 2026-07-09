using DCMS.Application.Contracts.Repositories;
using DCMS.Domain.Entities;

namespace DCMS.Persistence.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DCMSDBContext db) : base(db)
        {
        }
    }   
}

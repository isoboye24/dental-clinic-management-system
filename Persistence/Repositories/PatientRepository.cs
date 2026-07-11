using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Features.Patients.Queries.GetPatientsList;
using DCMS.Domain.Entities;
using DCMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DCMS.Persistence.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly DCMSDBContext _db;
        public PatientRepository(DCMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Patient>> GetFiltered(PatientsFilterDTO filter)
        {
            return await _db.Patients
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }
    }   
}

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
            var query = _db.Patients.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            if (!string.IsNullOrWhiteSpace(filter.Email))
            {
                query = query.Where(p => p.Email.Value.Contains(filter.Email));
            }

            return await query
                .OrderBy(x => x.Name)
                .Paginate(filter.Page, filter.RecordsPerPage)
                .ToListAsync();
        }
    }   
}

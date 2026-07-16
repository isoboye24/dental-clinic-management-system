using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Features.Dentists.Queries.GetDentistsList;
using DCMS.Domain.Entities;
using DCMS.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DCMS.Persistence.Repositories
{
    public class DentistRepository : Repository<Dentist>, IDentistRepository
    {
        private readonly DCMSDBContext _db;
        public DentistRepository(DCMSDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Dentist>> GetFiltered(DentistFilterDTO
            filter)
        {
            var query = _db.Dentists.AsQueryable();

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

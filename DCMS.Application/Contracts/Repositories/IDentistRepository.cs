using DCMS.Domain.Entities;
using DCMS.Application.Features.Dentists.Queries.GetDentistsList;

namespace DCMS.Application.Contracts.Repositories
{
    public interface IDentistRepository : IRepository<Dentist>
    {
        Task<IEnumerable<Dentist>> GetFiltered(DentistFilterDTO filter);
    }
}

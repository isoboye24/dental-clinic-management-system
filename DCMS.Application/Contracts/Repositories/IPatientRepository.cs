using DCMS.Application.Features.Patients.Queries.GetPatientsList;
using DCMS.Domain.Entities;

namespace DCMS.Application.Contracts.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetFiltered(PatientsFilterDTO filter);
    }
}

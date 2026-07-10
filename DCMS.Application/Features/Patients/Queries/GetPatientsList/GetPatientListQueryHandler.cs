using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientListQueryHandler : IRequestHandler<GetPatientListQuery, List<PatientListDTO>>
    {
        private readonly IPatientRepository _repository;
        public GetPatientListQueryHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PatientListDTO>> Handle(GetPatientListQuery request)
        {
            var patients = await _repository.GetAll();
            var patientList = patients.Select(p => p.ToDTO()).ToList();
            return patientList;
        }
    }
}

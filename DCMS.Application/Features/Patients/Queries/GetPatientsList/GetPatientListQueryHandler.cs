using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Utilities;
using DCMS.Application.Utilities.Common;

namespace DCMS.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientListQueryHandler : IRequestHandler<GetPatientListQuery, PaginatedDTO<PatientListDTO>>
    {
        private readonly IPatientRepository _repository;
        public GetPatientListQueryHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<PatientListDTO>> Handle(GetPatientListQuery request)
        {
            var patients = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var patientList = patients.Select(p => p.ToDTO()).ToList();

            var paginatedResult = new PaginatedDTO<PatientListDTO>
            {
                Elements = patientList,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedResult;
        }
    }
}

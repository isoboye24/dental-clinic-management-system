using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Exceptions;
using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Patients.Queries.GetPatientsDetail
{
    public class GetPatientDetailQueryHandler : IRequestHandler<GetPatientDetailQuery, PatientDetailDTO>
    {
        private readonly IPatientRepository _repository;
        public GetPatientDetailQueryHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<PatientDetailDTO> Handle(GetPatientDetailQuery request)
        {
            var patient = await _repository.GetById(request.Id);

            if (patient is null)
            {
                throw new NotFoundException("Patient is not found");
            }

            return patient.ToDTO();
        }
    }
}

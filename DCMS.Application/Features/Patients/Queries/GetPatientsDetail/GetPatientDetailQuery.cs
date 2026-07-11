using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Patients.Queries.GetPatientsDetail
{
    public class GetPatientDetailQuery : IRequest<PatientDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}

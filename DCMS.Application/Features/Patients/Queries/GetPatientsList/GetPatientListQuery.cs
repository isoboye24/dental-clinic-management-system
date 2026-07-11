using DCMS.Application.Utilities;
using DCMS.Application.Utilities.Common;

namespace DCMS.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientListQuery : PatientsFilterDTO, IRequest<PaginatedDTO<PatientListDTO>>
    {
    }
}

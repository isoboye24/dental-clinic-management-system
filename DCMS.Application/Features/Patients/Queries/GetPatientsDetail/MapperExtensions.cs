using DCMS.Domain.Entities;

namespace DCMS.Application.Features.Patients.Queries.GetPatientsDetail
{
    internal static class MapperExtensions
    {
        internal static PatientDetailDTO ToDTO(this Patient patient)
        {
            return new PatientDetailDTO
            {
                Id = patient.Id,
                Name = patient.Name,
                Email = patient.Email.Value
            };
        }
    }
}

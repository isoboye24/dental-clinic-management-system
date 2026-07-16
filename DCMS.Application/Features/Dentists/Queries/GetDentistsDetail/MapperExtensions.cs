using DCMS.Domain.Entities;

namespace DCMS.Application.Features.Dentists.Queries.GetDentistsDetail
{
    internal static class MapperExtensions
    {
        internal static DentistDetailDTO ToDTO(this Dentist dentist)
        {
            return new DentistDetailDTO
            {
                Id = dentist.Id,
                Name = dentist.Name,
                Email = dentist.Email.Value
            };
        }
    }
}

using DCMS.Domain.Entities;

namespace DCMS.Application.Features.Dentists.Queries.GetDentistsList
{
    internal static class MapperExtensions
    {
        internal static DentistListDTO ToDTO(this Dentist dentist)
        {
            return new DentistListDTO
            {
                Id = dentist.Id,
                Name = dentist.Name,
                Email = dentist.Email.Value
            };
        }
    }
}

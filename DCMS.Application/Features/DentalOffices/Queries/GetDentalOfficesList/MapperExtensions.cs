using DCMS.Domain.Entities;

namespace DCMS.Application.Features.DentalOffices.Queries.GetDentalOfficesList
{
    internal static class MapperExtensions
    {
        public static DentalOfficesListDTO ToDTO(this DentalOffice dentalOffice)
        {
            return new DentalOfficesListDTO
            {
                Id = dentalOffice.Id,
                Name = dentalOffice.Name
            };
        }
    }
}

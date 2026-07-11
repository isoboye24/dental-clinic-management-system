using DCMS.Domain.Entities;

namespace DCMS.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    internal static class MapperExtensions
    {
        public static DentalOfficeDetailDTO ToDTO(this DentalOffice dentalOffice)
        {
            return new DentalOfficeDetailDTO
            {
                Id = dentalOffice.Id,
                Name = dentalOffice.Name
            };
        }
    }
}

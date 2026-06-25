using DCMS.Application.Utilities;

namespace DCMS.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    public class GetDentalOfficeDetailQuery : IRequest<DentalOfficeDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}

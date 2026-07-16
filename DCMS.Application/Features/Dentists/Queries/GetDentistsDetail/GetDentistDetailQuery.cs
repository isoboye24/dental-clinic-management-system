using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Dentists.Queries.GetDentistsDetail
{
    public class GetDentistDetailQuery : IRequest<DentistDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}

using DCMS.Application.Utilities;
using DCMS.Application.Utilities.Common;

namespace DCMS.Application.Features.Dentists.Queries.GetDentistsList
{
    public class GetDentistListQuery : DentistFilterDTO, IRequest<PaginatedDTO<DentistListDTO>>
    {
    }
}

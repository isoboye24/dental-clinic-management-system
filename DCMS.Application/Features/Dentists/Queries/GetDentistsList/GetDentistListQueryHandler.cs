using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Utilities;
using DCMS.Application.Utilities.Common;

namespace DCMS.Application.Features.Dentists.Queries.GetDentistsList
{
    public class GetDentistListQueryHandler : IRequestHandler<GetDentistListQuery, PaginatedDTO<DentistListDTO>>
    {
        private readonly IDentistRepository _repository;
        public GetDentistListQueryHandler(IDentistRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDTO<DentistListDTO>> Handle(GetDentistListQuery request)
        {
            var dentists = await _repository.GetFiltered(request);
            var totalAmountOfRecords = await _repository.GetTotalAmountOfRecords();
            var dentistList = dentists.Select(d => d.ToDTO()).ToList();
            var paginatedResult = new PaginatedDTO<DentistListDTO>
            {
                Elements = dentistList,
                TotalAmountOfRecords = totalAmountOfRecords
            };
            return paginatedResult;
        }
    }
}

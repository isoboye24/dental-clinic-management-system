using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Utilities;

namespace DCMS.Application.Features.DentalOffices.Queries.GetDentalOfficesList
{
    public class GetDentalOfficesListQueryHandler : IRequestHandler<GetDentalOfficeListQuery, List<DentalOfficesListDTO>>
    {
        private readonly IDentalOfficeRepository _repository;
        public GetDentalOfficesListQueryHandler(IDentalOfficeRepository repository)
        {
             _repository = repository;
        }

        public async Task<List<DentalOfficesListDTO>> Handle(GetDentalOfficeListQuery request)
        {
            var dentalOffices = await _repository.GetAll();
            var dentalOfficesList = dentalOffices.Select(dentalOffice => dentalOffice.ToDTO()).ToList();

            return dentalOfficesList;
        }
    }
}

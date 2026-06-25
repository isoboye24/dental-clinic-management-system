using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Exceptions;
using DCMS.Application.Utilities;

namespace DCMS.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    public class GetDentalOfficeDetailQueryHandler : IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDTO>
    {
        private readonly IDentalOfficeRepository _repository;
        public GetDentalOfficeDetailQueryHandler(IDentalOfficeRepository repository)
        {
            _repository = repository;
        }

        public async Task<DentalOfficeDetailDTO> Handle(GetDentalOfficeDetailQuery request)
        {
            var dentalOffice = await _repository.GetById(request.Id);

            if (dentalOffice is null)
            {
                throw new NotFoundException();
            }

            var dto = new DentalOfficeDetailDTO
            {
                Id = dentalOffice.Id,
                Name = dentalOffice.Name
            };

            return dto;
        }
    }
}

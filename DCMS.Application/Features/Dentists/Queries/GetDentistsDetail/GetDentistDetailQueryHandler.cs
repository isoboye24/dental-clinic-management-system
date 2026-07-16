using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Exceptions;
using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Dentists.Queries.GetDentistsDetail
{
    public class GetDentistDetailQueryHandler : IRequestHandler<GetDentistDetailQuery, DentistDetailDTO>
    {
        private readonly IDentistRepository _repository;
        public GetDentistDetailQueryHandler(IDentistRepository repository)
        {
            _repository = repository;
        }

        public async Task<DentistDetailDTO> Handle(GetDentistDetailQuery request)
        {
            var dentist = await _repository.GetById(request.Id);

            if (dentist is null)
            {
                throw new NotFoundException("Dentist is not found");
            }

            return dentist.ToDTO();
        }    
    }
}

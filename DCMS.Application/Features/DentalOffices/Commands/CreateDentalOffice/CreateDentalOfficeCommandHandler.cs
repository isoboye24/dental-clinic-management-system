using DCMS.Application.Contracts.Repositories;
using DCMS.Domain.Entities;

namespace DCMS.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommandHandler
    {
        private readonly IDentalOfficeRepository _repository;
        public CreateDentalOfficeCommandHandler(IDentalOfficeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateDentalOfficeCommand command)
        {
            var dentalOffice = new DentalOffice(command.Name);
            var result = await _repository.Add(dentalOffice);
            return result.Id;
        }
    }
}

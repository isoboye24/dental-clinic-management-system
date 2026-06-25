using DCMS.Application.Contracts.Persistence;
using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Exceptions;
using DCMS.Application.Utilities;
using DCMS.Domain.Entities;
using FluentValidation;

namespace DCMS.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommandHandler : IRequestHandler<CreateDentalOfficeCommand, Guid>
    {
        private readonly IDentalOfficeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDentalOfficeCommandHandler(IDentalOfficeRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateDentalOfficeCommand command)
        {
            var dentalOffice = new DentalOffice(command.Name);
            try
            {
                var result = await _repository.Add(dentalOffice);
                await _unitOfWork.Commit();
                return result.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
            
        }
    }
}


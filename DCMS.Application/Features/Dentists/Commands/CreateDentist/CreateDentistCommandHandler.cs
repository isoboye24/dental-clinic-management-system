using DCMS.Application.Contracts.Persistence;
using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Utilities;
using DCMS.Domain.Entities;
using DCMS.Domain.ValueObjects;

namespace DCMS.Application.Features.Dentists.Commands.CreateDentist
{
    public class CreateDentistCommandHandler : IRequestHandler<CreateDentistCommand, Guid>
    {
        private readonly IDentistRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateDentistCommandHandler(IDentistRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateDentistCommand request)
        {
            var email = new Email(request.Email);
            var dentist = new Dentist(request.Name, email);
            try
            {
                var result = await _repository.Add(dentist);
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

using DCMS.Application.Contracts.Persistence;
using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Exceptions;
using DCMS.Application.Utilities;
using DCMS.Domain.ValueObjects;

namespace DCMS.Application.Features.Dentists.Commands.UpdateDentist
{    
    public class UpdateDentistCommandHandler : IRequestHandler<UpdateDentistCommand>
    {
        private readonly IDentistRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDentistCommandHandler(IDentistRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateDentistCommand request)
        {
            var dentist = await _repository.GetById(request.Id);

            if (dentist is null)
            {
                throw new NotFoundException("Dentist is required");
            }
            dentist.UpdateName(request.Name);
            var email = new Email(request.Email);
            dentist.UpdateEmail(email);

            try
            {
                await _repository.Update(dentist);
                await _unitOfWork.Commit();

            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}

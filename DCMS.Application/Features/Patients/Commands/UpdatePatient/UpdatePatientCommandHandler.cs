using DCMS.Application.Contracts.Persistence;
using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Exceptions;
using DCMS.Application.Utilities;
using DCMS.Domain.ValueObjects;

namespace DCMS.Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
    {
        private readonly IPatientRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePatientCommandHandler(IPatientRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdatePatientCommand request)
        {
            var patient = await _repository.GetById(request.Id);

            if (patient is null)
            {
                throw new NotFoundException("Patient is required");
            }
            patient.UpdateName(request.Name);
            var email = new Email(request.Email);
            patient.UpdateEmail(email);

            try
            {
                await _repository.Update(patient);
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

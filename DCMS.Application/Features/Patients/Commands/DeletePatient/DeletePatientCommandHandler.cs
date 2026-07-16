using DCMS.Application.Contracts.Persistence;
using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Exceptions;
using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Patients.Commands.DeletePatient
{    
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
    {
        private readonly IPatientRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeletePatientCommandHandler(IPatientRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeletePatientCommand request)
        {
            var patient = await _repository.GetById(request.Id);

            if (patient is null)
            {
                throw new NotFoundException("Patient not found");
            }

            try
            {
                await _repository.Delete(patient);
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

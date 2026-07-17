using DCMS.Application.Contracts.Persistence;
using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Exceptions;
using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Dentists.Commands.DeleteDentist
{
    public class DeleteDentistCommandHandler : IRequestHandler<DeleteDentistCommand>
    {
        private readonly IDentistRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDentistCommandHandler(IDentistRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteDentistCommand request)
        {
            var dentist = await _repository.GetById(request.Id);
            if (dentist is null)
            {
                throw new NotFoundException("Dentist not found");
            }
            try
            {
                await _repository.Delete(dentist);
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

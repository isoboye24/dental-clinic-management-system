using DCMS.Application.Contracts.Persistence;
using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Exceptions;
using DCMS.Application.Utilities;

namespace DCMS.Application.Features.DentalOffices.Commands.UpdateDentalOffice
{
    public class UpdateDentalOfficeCommandHandler : IRequestHandler<UpdateDentalOfficeCommand>
    {
        private readonly IDentalOfficeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDentalOfficeCommandHandler(IDentalOfficeRepository repository, IUnitOfWork unitOfWork)
        {
             _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateDentalOfficeCommand request)
        {
            var dentalOffice = await _repository.GetById(request.Id);

            if (dentalOffice is null)
            {
                throw new NotFoundException("Dental office is required");
            }
            dentalOffice.UpdateName(request.Name);

            try
            {
                await _repository.Update(dentalOffice);
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

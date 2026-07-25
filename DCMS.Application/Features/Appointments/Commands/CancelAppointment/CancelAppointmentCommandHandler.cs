using DCMS.Application.Utilities;
using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Contracts.Persistence;

namespace DCMS.Application.Features.Appointments.Commands.CancelAppointment
{
    public class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand>
    {
        private readonly IAppointmentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public CancelAppointmentCommandHandler(IAppointmentRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CancelAppointmentCommand request)
        {
            var appointment = await _repository.GetById(request.Id);
            if (appointment == null)
            {
                throw new InvalidOperationException("Appointment not found");
            }
            
            appointment.Cancel();

            try
            {
                await _repository.Update(appointment);
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

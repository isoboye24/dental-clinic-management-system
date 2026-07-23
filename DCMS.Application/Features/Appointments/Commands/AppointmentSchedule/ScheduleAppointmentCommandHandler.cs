using DCMS.Application.Contracts.Persistence;
using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Exceptions;
using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Appointments.Commands.AppointmentSchedule
{
    public class ScheduleAppointmentCommandHandler : IRequestHandler<ScheduleAppointmentCommand>
    {
        private readonly IAppointmentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleAppointmentCommandHandler(IAppointmentRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ScheduleAppointmentCommand request)
        {
            var appointment = await _repository.GetById(request.Id);

            if (appointment == null)
            {
                throw new NotFoundException("Appointment not found");
            }

            appointment.Schedule();

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

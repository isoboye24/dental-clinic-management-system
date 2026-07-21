using DCMS.Application.Contracts.Persistence;
using DCMS.Application.Contracts.Repositories;
using DCMS.Domain.Entities;
using DCMS.Application.Utilities;
using DCMS.Application.Exceptions;
using DCMS.Domain.ValueObjects;

namespace DCMS.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Guid>
    {
        private readonly IAppointmentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAppointmentCommandHandler(IAppointmentRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Guid> Handle(CreateAppointmentCommand command)
        {
            // Check for overlapping appointments
            bool overlapExists = await _repository.OverlapExists(command.DentistId, command.StartDate, command.EndDate);
            
            if (overlapExists)
            {
                throw new CustomValidationException("The appointment overlaps with an existing appointment.");
            }

            var timeInterval = new TimeInterval(command.StartDate, command.EndDate);
            var appointment = new Appointment(command.PatientId, command.DentistId, command.DentistOfficeId, timeInterval);
            try
            {
                var result = await _repository.Add(appointment);
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

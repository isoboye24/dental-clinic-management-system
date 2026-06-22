using DCMS.Domain.Enums;
using DCMS.Domain.Exceptions;

namespace DCMS.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DentistId { get; private set; }
        public Guid DentalOfficeId { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public Patient? Patient { get; private set; }
        public Dentist? Dentist { get; private set; }
        public DentalOffice? DentalOffice { get; private set; }

        public Appointment(
           Guid patientId,
           Guid dentistId,
           Guid dentalOfficeId,
           DateTime startTime,
           DateTime endTime)
        {
            if (patientId == Guid.Empty)
                throw new BusinessRuleException("Patient is required.");

            if (dentistId == Guid.Empty)
                throw new BusinessRuleException("Dentist is required.");

            if (dentalOfficeId == Guid.Empty)
                throw new BusinessRuleException("Dental office is required.");

            if (startTime == default)
                throw new BusinessRuleException("Start time is required.");

            if (endTime == default)
                throw new BusinessRuleException("End time is required.");

            if (endTime <= startTime)
                throw new BusinessRuleException("End time must be after start time.");

            Id = Guid.CreateVersion7();
            PatientId = patientId;
            DentistId = dentistId;
            DentalOfficeId = dentalOfficeId;
            StartTime = startTime;
            EndTime = endTime;
            Status = AppointmentStatus.Pending;
        }

        public void Confirm()
        {
            if (Status != AppointmentStatus.Pending)
            {
                throw new BusinessRuleException("Only pending status can be confirmed");
            }

            Status = AppointmentStatus.Confirmed;
        }

        public void Complete()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled status can be completed");
            }

            Status = AppointmentStatus.Completed;
        }

        public void Cancel()
        {
            if (Status != AppointmentStatus.Pending || Status != AppointmentStatus.Confirmed)
            {
                throw new BusinessRuleException("Only pending and confirmed status can be cancelled");
            }

            Status = AppointmentStatus.Cancelled;
        }
    }
}

using DCMS.Domain.Enums;
using DCMS.Domain.Exceptions;
using DCMS.Domain.ValueObjects;

namespace DCMS.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DentistId { get; private set; }
        public Guid DentalOfficeId { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public TimeInterval TimeInterval { get; private set; } = null!;
        public Patient? Patient { get; private set; }
        public Dentist? Dentist { get; private set; }
        public DentalOffice? DentalOffice { get; private set; }

        private Appointment()
        {
            
        }

        public Appointment(
           Guid patientId,
           Guid dentistId,
           Guid dentalOfficeId,
           TimeInterval timeInterval)
        {
            if (patientId == Guid.Empty)
                throw new BusinessRuleException("Patient is required.");

            if (dentistId == Guid.Empty)
                throw new BusinessRuleException("Dentist is required.");

            if (dentalOfficeId == Guid.Empty)
                throw new BusinessRuleException("Dental office is required.");

            if (timeInterval.Start == default)
                throw new BusinessRuleException("Start time is required.");

            if (timeInterval.End == default)
                throw new BusinessRuleException("End time is required.");

            //if (timeInterval.Start < DateTime.UtcNow)
            //    throw new BusinessRuleException("Start time must be earlier than end time.");

            Id = Guid.CreateVersion7();
            PatientId = patientId;
            DentistId = dentistId;
            DentalOfficeId = dentalOfficeId;
            TimeInterval = timeInterval;
            Status = AppointmentStatus.Pending;
        }

        public void Pending()
        {
            if (Status != AppointmentStatus.Pending)
            {
                throw new BusinessRuleException(
                    "Only pending appointments can be Pending.");
            }

            Status = AppointmentStatus.Pending;
        }
        
        public void Schedule()
        {
            if (Status != AppointmentStatus.Pending)
            {
                throw new BusinessRuleException(
                    "Only pending appointments can be scheduled.");
            }

            Status = AppointmentStatus.Scheduled;
        }

        public void Complete()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled appointments can be completed");
            }

            Status = AppointmentStatus.Completed;
        }

        public void Cancel()
        {
            if (Status != AppointmentStatus.Pending 
                && Status != AppointmentStatus.Scheduled 
                && Status != AppointmentStatus.Completed)
            {
                throw new BusinessRuleException("Only pending or scheduled or completed appointments can be cancelled");
            }

            Status = AppointmentStatus.Cancelled;
        }
    }
}

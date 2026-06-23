using DCMS.Domain.Entities;
using DCMS.Domain.Enums;
using DCMS.Domain.Exceptions;
using DCMS.Domain.ValueObjects;

namespace DCMS.Test.Domain.Entities
{
    [TestClass]
    public class AppointmentTests
    {
        private Guid _patientId = Guid.NewGuid();
        private Guid _dentistId = Guid.NewGuid();
        private Guid _dentalOfficeId = Guid.NewGuid();
        private TimeInterval _interval = new TimeInterval(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));

        [TestMethod]
        public void Constructor_EmptyPatientId_ThrowsBusinessRuleException()
        {
            var ex = Assert.Throws<BusinessRuleException>(
                () => new Appointment(
                    Guid.Empty,
                    _dentistId,
                    _dentalOfficeId,
                    _interval));

            Assert.AreEqual("Patient is required.", ex.Message);
        }

        [TestMethod]
        public void Constructor_ValidAppointment_StatusPending()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);

            Assert.AreEqual(_patientId, appointment.PatientId);
            Assert.AreEqual(_dentistId, appointment.DentistId);
            Assert.AreEqual(_dentalOfficeId, appointment.DentalOfficeId);
            Assert.AreEqual(_interval, appointment.TimeInterval);
            Assert.AreEqual(AppointmentStatus.Pending, appointment.Status);
            Assert.AreNotEqual(Guid.Empty, appointment.Id);
        }

        [TestMethod]
        public void Constructor_StartTimeInThePast_ThrowsBusinessRuleException()
        {
            var interval = new TimeInterval(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow.AddHours(1));

            var ex = Assert.Throws<BusinessRuleException>(
            () => new Appointment(
                _patientId,
                _dentistId,
                _dentalOfficeId,
                interval));

            Assert.AreEqual(
                "Start time must be earlier than end time.",
                ex.Message);
        }

        [TestMethod]
        public void Cancel_PendingAppointment_ChangesStatusToCancelled()
        {
            var appointment = new Appointment(
            _patientId,
            _dentistId,
            _dentalOfficeId,
            _interval);

            appointment.Pending();
            appointment.Cancel();

            Assert.AreEqual(
                AppointmentStatus.Cancelled,
                appointment.Status);
        }

        [TestMethod]
        public void Cancel_CancelAppointment_ChangesStatusToCancelled()
        {
            var appointment = new Appointment(
            _patientId,
            _dentistId,
            _dentalOfficeId,
            _interval);

            appointment.Cancel();

            Assert.AreEqual(
                AppointmentStatus.Cancelled,
                appointment.Status);
        }

        [TestMethod]
        public void Cancel_ScheduledAppointment_ChangesStatusToCancelled()
        {
            var appointment = new Appointment(
                _patientId,
                _dentistId,
                _dentalOfficeId,
                _interval);

            appointment.Schedule();

            appointment.Cancel();

            Assert.AreEqual(
                AppointmentStatus.Cancelled,
                appointment.Status);
        }
        
        [TestMethod]
        public void Cancel_CompletedAppointment_ChangesStatusToCancelled()
        {
            var appointment = new Appointment(
                _patientId,
                _dentistId,
                _dentalOfficeId,
                _interval);

            appointment.Schedule();
            appointment.Complete();
            appointment.Cancel();

            Assert.AreEqual(
                AppointmentStatus.Cancelled,
                appointment.Status);
        }

        [TestMethod]
        public void Schedule_ScheduledAppointment_ChangesStatusToScheduled()
        {
            var appointment = new Appointment(
                _patientId,
                _dentistId,
                _dentalOfficeId,
                _interval);

            appointment.Pending();

            appointment.Schedule();

            Assert.AreEqual(
                AppointmentStatus.Scheduled,
                appointment.Status);
        }

        [TestMethod]
        public void Complete_CompletedAppointment_ChangesStatusToCompleted()
        {
            var appointment = new Appointment(
                _patientId,
                _dentistId,
                _dentalOfficeId,
                _interval);

            appointment.Schedule();

            appointment.Complete();

            Assert.AreEqual(
                AppointmentStatus.Completed,
                appointment.Status);
        }
    }
}

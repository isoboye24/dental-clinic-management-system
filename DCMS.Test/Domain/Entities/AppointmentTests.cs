using DCMS.Domain.Entities;
using DCMS.Domain.Enums;
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
    }
}

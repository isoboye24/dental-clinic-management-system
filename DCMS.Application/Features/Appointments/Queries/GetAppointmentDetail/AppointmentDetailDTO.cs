namespace DCMS.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    public class AppointmentDetailDTO
    {
        public required Guid Id { get; set; }
        public required string Patient { get; set; }
        public required string Dentist { get; set; }
        public required string DentalOffice { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required string Status { get; set; }
    }
}

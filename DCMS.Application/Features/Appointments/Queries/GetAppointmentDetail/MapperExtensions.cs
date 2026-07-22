using DCMS.Domain.Entities;

namespace DCMS.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    internal static class MapperExtensions
    {
        internal static AppointmentDetailDTO ToAppointmentDetailDTO(this Appointment appointment)
        {
            return new AppointmentDetailDTO
            {
                Id = appointment.Id,
                StartTime = appointment.TimeInterval.Start,
                EndTime = appointment.TimeInterval.End,
                Patient = appointment.Patient!.Name,
                Dentist = appointment.Dentist!.Name,
                DentalOffice = appointment.DentalOffice!.Name,
                Status = appointment.Status.ToString()
            };
        }
    }
}

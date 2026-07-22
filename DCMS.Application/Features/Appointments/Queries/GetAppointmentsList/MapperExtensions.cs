namespace DCMS.Application.Features.Appointments.Queries.GetAppointmentsList
{
    internal static class MapperExtensions
    {
        internal static AppointmentsListDTO ToAppointmentsListDTO(this Domain.Entities.Appointment appointment)
        {
            return new AppointmentsListDTO
            {
                Id = appointment.Id,
                Patient = appointment.Patient!.Name,
                Dentist = appointment.Dentist!.Name,
                DentalOffice = appointment.DentalOffice!.Name,
                StartDate = appointment.TimeInterval.Start,
                EndDate = appointment.TimeInterval.End
            };
        }
    }
}

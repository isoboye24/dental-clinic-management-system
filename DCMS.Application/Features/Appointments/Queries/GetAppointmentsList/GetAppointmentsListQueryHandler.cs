using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class GetAppointmentsListQueryHandler : IRequestHandler<GetAppointmentsListQuery, List<AppointmentsListDTO>>
    {
        private readonly IAppointmentRepository _repository;
        public GetAppointmentsListQueryHandler(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AppointmentsListDTO>> Handle(GetAppointmentsListQuery request)
        {
            var appointments = await _repository.GetFilter(request);
            return appointments.Select(a => new AppointmentsListDTO
            {
                Id = a.Id,
                Patient = a.Patient!.Name,
                Dentist = a.Dentist!.Name,
                DentalOffice = a.DentalOffice!.Name,
                StartDate = a.TimeInterval.Start,
                EndDate = a.TimeInterval.End
            }).ToList();
        }
    }
}

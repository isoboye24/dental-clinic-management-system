using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Utilities;
using DCMS.Application.Exceptions;

namespace DCMS.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    public class GetAppointmentDetailHandler : IRequestHandler<GetAppointmentDetailQuery, AppointmentDetailDTO>
    {
        private readonly IAppointmentRepository _repository;
        public GetAppointmentDetailHandler(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<AppointmentDetailDTO> Handle(GetAppointmentDetailQuery request)
        {
           var appointment = await _repository.GetById(request.Id);
            if (appointment is null)
            {
                throw new NotFoundException("Appointment is not found");
            }
            return appointment.ToAppointmentDetailDTO();
        }
    }
}

using DCMS.API.DTOs.Appointments;
using DCMS.Application.Features.Appointments.Queries.GetAppointmentDetail;
using DCMS.Application.Features.Appointments.Commands.CreateAppointment;
using DCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;
using DCMS.Application.Features.Appointments.Queries.GetAppointmentsList;

namespace DCMS.API.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentDTO createAppointmentDTO)
        {
            var command = new CreateAppointmentCommand
            {
                PatientId = createAppointmentDTO.PatientId,
                DentistId = createAppointmentDTO.DentistId,
                DentistOfficeId = createAppointmentDTO.DentistOfficeId,
                StartDate = createAppointmentDTO.StartDate,
                EndDate = createAppointmentDTO.EndDate
            };
            var result = await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetAppointmentDetailQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<AppointmentsListDTO>>> GetAll([FromQuery] GetAppointmentsListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

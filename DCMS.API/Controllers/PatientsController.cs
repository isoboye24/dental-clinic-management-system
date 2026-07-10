using DCMS.API.DTOs.Patients;
using DCMS.Application.Features.Patients.Commands.CreatePatients;
using DCMS.Application.Features.Patients.Queries.GetPatientsList;
using DCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DCMS.API.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientDTO createPatientDTO)
        {
            var command = new CreatePatientCommand
            {
                Name = createPatientDTO.Name,
                Email = createPatientDTO.Email,
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientListDTO>>> GetAll()
        {
            var query = new GetPatientListQuery();
            var result = await _mediator.Send(query);
            return result;
        }
    }
}

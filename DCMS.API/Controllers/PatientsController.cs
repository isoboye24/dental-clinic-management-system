using DCMS.API.DTOs.Patients;
using DCMS.API.Utilities;
using DCMS.Application.Features.Patients.Commands.CreatePatients;
using DCMS.Application.Features.Patients.Queries.GetPatientsDetail;
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
        public async Task<ActionResult<List<PatientListDTO>>> GetAll([FromQuery] GetPatientListQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Elements;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDetailDTO>> GetById(Guid id)
        {
            var query = new GetPatientDetailQuery { Id = id };
            return await _mediator.Send(query);
        }
    }
}

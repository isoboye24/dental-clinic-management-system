using DCMS.API.DTOs.DentalOffices;
using DCMS.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using DCMS.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using DCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DCMS.API.Controllers
{
    [ApiController]
    [Route("api/dentaloffices")]
    public class DentalOfficesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DentalOfficesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDentalOfficeDTO createDentalOfficeDTO)
        {
            var command = new CreateDentalOfficeCommand { Name = createDentalOfficeDTO.Name};
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DentalOfficeDetailDTO>> GetById(Guid id)
        {
            var query = new GetDentalOfficeDetailQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
}
}

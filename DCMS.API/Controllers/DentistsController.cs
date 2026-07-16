using DCMS.API.DTOs.Dentists;
using DCMS.API.Utilities;
using DCMS.Application.Features.Dentists.Commands.CreateDentist;
using DCMS.Application.Features.Dentists.Queries.GetDentistsList;
using DCMS.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DCMS.API.Controllers
{
    [ApiController]
    [Route("api/dentists")]
    public class DentistsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DentistsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDentistDTO createDentistDTO)
        {
            var command = new CreateDentistCommand
            {
                Name = createDentistDTO.Name,
                Email = createDentistDTO.Email,
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<DentistListDTO>>> GetAll([FromQuery] GetDentistListQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Elements;
        }
    }
}

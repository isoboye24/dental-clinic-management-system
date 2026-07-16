using DCMS.API.DTOs.Dentists;
using DCMS.Application.Features.Dentists.Commands.CreateDentist;
using Microsoft.AspNetCore.Mvc;
using DCMS.Application.Utilities;

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
    }
}

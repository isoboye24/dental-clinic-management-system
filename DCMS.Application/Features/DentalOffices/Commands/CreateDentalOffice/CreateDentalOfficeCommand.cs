using DCMS.Application.Utilities;

namespace DCMS.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}

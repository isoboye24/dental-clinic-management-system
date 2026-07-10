using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Patients.Commands.CreatePatients
{
    public class CreatePatientCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}

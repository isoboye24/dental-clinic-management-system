using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Dentists.Commands.DeleteDentist
{
    public class DeleteDentistCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}

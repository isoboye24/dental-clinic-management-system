using DCMS.Application.Utilities;

namespace DCMS.Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientCommand : IRequest
    {
        public required Guid Id { get; set; }
    }    
}

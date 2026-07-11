namespace DCMS.Application.Features.Patients.Queries.GetPatientsDetail
{
    public class PatientDetailDTO
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}

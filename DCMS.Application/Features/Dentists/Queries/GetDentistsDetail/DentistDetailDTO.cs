namespace DCMS.Application.Features.Dentists.Queries.GetDentistsDetail
{
    public class DentistDetailDTO
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}

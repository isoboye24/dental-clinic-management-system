namespace DCMS.Application.Features.Dentists.Queries.GetDentistsList
{
    public class DentistListDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}

namespace DCMS.Application.Features.Dentists.Queries.GetDentistsList
{
    public class DentistFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}

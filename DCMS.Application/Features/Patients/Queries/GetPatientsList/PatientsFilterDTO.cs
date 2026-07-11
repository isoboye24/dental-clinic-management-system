namespace DCMS.Application.Features.Patients.Queries.GetPatientsList
{
    public class PatientsFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
    }
}

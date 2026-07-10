using System.ComponentModel.DataAnnotations;

namespace DCMS.API.DTOs.Patients
{
    public class CreatePatientDTO
    {
        [Required]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public required string Name { get; set; }

        [Required]
        [StringLength(254)]
        [EmailAddress]
        public required string Email { get; set; }
    }
}

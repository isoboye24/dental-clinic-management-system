using System.ComponentModel.DataAnnotations;

namespace DCMS.API.DTOs.DentalOffices
{
    public class UpdateDentalOfficeDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public required string Name { get; set; }
    }
}

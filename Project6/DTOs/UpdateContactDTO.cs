using System.ComponentModel.DataAnnotations;

namespace Project6.DTOs
{
    public class UpdateContactDTO
    {
        [RegularExpression(@"^\d{10}$",
        ErrorMessage = "Phone number must be exactly 10 digits.")]
        public int? OldPhoneNumber { get; set; }

        [RegularExpression(@"^\d{10}$",
        ErrorMessage = "Phone number must be exactly 10 digits.")]
        public int? NewPhoneNumber { get; set; }

        [RegularExpression("^(?i)(work|home|personal)$")]
        public string? ContactType { get; set; }
    }
}

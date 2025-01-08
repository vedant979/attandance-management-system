using System.ComponentModel.DataAnnotations;

namespace Project6.DTOs
{
    public class AddContactDTO
    {
        [RegularExpression(@"^\d{10}$",
            ErrorMessage = "Phone number must be exactly 10 digits.")]
        public int? PhoneNumber { get; set; }

        [RegularExpression("^(?i)(work|home|personal)$")]
        public string? ContactType   { get; set; }

    }
}

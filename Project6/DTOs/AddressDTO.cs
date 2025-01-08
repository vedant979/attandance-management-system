using System.ComponentModel.DataAnnotations;

namespace Project6.DTOs
{
    public class AddressDTO
    {
        [Required]
        [RegularExpression(@"^\d+\s[A-Za-z0-9\s.,'-]+$", ErrorMessage = "Enter a valid Street")]
        public string? Street { get; set; }

        [Required]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Please enter a valid Pincode.")]
        public string? PinCode { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Enter a valid city")]
        public string? City { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Enter a valid state")]
        public string? State { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Enter a valid country")]
        public string? Country { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s\-\/]+$")]
        public string? Houseno { get; set; }


        [Required]
        [RegularExpression("^(?i)(work|current|permanent)$")]
        public string? AddressType { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Project6.DTOs
{
    public class ChangeUserCredentialDTO
    {
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,}$")]

        public string? OldPassword { get; set; }

        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,}$")]

        public string? NewPassword { get; set; }
    }
}

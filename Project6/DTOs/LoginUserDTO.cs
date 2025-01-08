using System.ComponentModel.DataAnnotations;

namespace Project6.DTOs
{
    public class LoginUserDTO
    {
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string? Email { get; set; }


        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,}$")]
        public string? Password { get; set; }
    }
}

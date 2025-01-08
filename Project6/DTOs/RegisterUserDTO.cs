using System.ComponentModel.DataAnnotations;

namespace Project6.DTOs
{
        public  class RegisterUserDTO
        {
            [Required(ErrorMessage = "FirstName is required.")]
            public string? FirstName { get; set; }

            [Required(ErrorMessage = "LastName is required.")]
            public string? LastName { get; set; }

            [Required(ErrorMessage = "Email is required.")]
            [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
            public string? Email { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,}$")]
            public string? Password { get; set; }
        }

    
}

using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Project6.DTOs
{
    public class UpdateMemberDTO
    {
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please select a gender.")]
        [RegularExpression("^(?i)(Male|Female|Other)$", ErrorMessage = "Invalid gender selected.")]
        public string? Gender { get; set; }

    }
}

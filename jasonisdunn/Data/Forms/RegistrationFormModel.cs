using System.ComponentModel.DataAnnotations;

namespace jasonisdunn.Data.Forms
{
    public class RegisterFormModel
    {
        [Required]
        [MaxLength(100)]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [DataType(DataType.Password)]
        [MaxLength(10)]
        [Compare("Password2")]
        public string? Password1 { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [DataType(DataType.Password)]
        [MaxLength(10)]

        public string? Password2 { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace jasonisdunn.Data
{
    public class EmailFormModel
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Message { get; set; }

    }
}


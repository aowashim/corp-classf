using System.ComponentModel.DataAnnotations;

namespace CorpClassfAuth.Data.Model
{
    public class SignUp
    {
        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required, MaxLength(20)]
        public string Designation { get; set; }

        [Required, MaxLength(30)]
        public string OfficeLocation { get; set; }
    }
}

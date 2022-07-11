using System.ComponentModel.DataAnnotations;

namespace CorpClassfAuth.Data.Model
{
    public class SignIn
    {
        [Required]
        public int EmpId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

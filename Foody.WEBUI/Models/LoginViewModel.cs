using System.ComponentModel.DataAnnotations;

namespace Foody.WEBUI.Models
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage ="Email zorunludur.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}

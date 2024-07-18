using System.ComponentModel.DataAnnotations;

namespace W7.D3.WebAuthenticationSample.Models
{
    public class LoginModel
    {
        [Display(Name = "Username")]
        [Required]
        public required string Username {  get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}

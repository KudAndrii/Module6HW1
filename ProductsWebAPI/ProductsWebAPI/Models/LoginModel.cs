using System.ComponentModel.DataAnnotations;

namespace ProductsWebAPI.Models
{
    public class LoginModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

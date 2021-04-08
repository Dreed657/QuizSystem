using System.ComponentModel.DataAnnotations;

namespace Server.Models.Identity
{
    public class LoginInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

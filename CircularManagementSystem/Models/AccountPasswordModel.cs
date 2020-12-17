using System.ComponentModel.DataAnnotations;

namespace CircularManagementSystem.Models
{
    public class AccountPasswordModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string ExistingPassword { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
    }
}
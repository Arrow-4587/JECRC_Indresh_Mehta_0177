using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrderingSystem.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
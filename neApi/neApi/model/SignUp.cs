using System.ComponentModel.DataAnnotations;

namespace neApi.model
{
    public class SignUp
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }=string.Empty;
        [Required]
        public string ConfirmPassword { get; set; }= string.Empty;
    }
}

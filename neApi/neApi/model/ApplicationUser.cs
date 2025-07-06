using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace neApi.model
{
    public class ApplicationUser:IdentityUser
    {
        [Required,EmailAddress]
        public string FirstName { get; set; }=string.Empty;
        [Required]
        public string LastName { get; set; }= string.Empty;

    }
}

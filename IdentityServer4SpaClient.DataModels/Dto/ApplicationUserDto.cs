using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using IdentityServer4.DataModels.Security;

namespace IdentityServer4.DataModels.Dto
{
    public class RegisterBindingModel: ApplicationUser
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

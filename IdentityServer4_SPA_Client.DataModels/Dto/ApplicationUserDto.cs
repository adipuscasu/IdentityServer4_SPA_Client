using IdentityServer4.DataModels.Security;

namespace IdentityServer4.DataModels.Dto
{
    public class ApplicationUserDto: ApplicationUser
    {
        public string Password { get; set; }
    }
}

using IdentityServer4.DataModels.Shared;
using Microsoft.AspNetCore.Identity;


namespace IdentityServer4.DataModels.Security
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string WebSite { get; set; }
        public Address Address { get; set; }
    }
}

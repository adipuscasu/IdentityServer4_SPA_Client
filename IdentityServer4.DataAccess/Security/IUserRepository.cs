using IdentityServer4.DataModels.Security;
using System.Collections.Generic;

namespace IdentityServer4.DataAccess.Security
{
    public interface IUserRepository
    {
        ApplicationUser GetUser(string id);
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser AddUser(ApplicationUser user);
        ApplicationUser UpdateUser(ApplicationUser user);

    }
}

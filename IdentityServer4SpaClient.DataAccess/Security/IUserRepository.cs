using IdentityServer4.DataModels.Security;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.DataAccess.Security
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetById(string id);
        IQueryable<ApplicationUser> GetUsers();
        Task<ApplicationUser> AddUser(ApplicationUser user);
        Task<ApplicationUser> UpdateUser(ApplicationUser user);

    }
}

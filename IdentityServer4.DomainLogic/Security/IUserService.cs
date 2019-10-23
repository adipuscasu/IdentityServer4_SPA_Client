using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.DataModels.Security;

namespace IdentityServer4.DomainLogic.Security
{
    public interface IUserService
    {
        Task<ApplicationUser> GetById(string id);
        IQueryable<ApplicationUser> GetUsers();
        Task<ApplicationUser> AddUser(ApplicationUser user);
        Task<ApplicationUser> UpdateUser(ApplicationUser user);
    }
}

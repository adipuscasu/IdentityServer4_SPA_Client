using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.DataAccess.Security;
using IdentityServer4.DataModels.Security;

namespace IdentityServer4.DomainLogic.Security
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            return await _userRepository.GetById(id);
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public async Task<ApplicationUser> AddUser(ApplicationUser user)
        {
            return await _userRepository.AddUser(user);
        }

        public async Task<ApplicationUser> UpdateUser(ApplicationUser user)
        {
            return await _userRepository.UpdateUser(user);
        }
    }
}

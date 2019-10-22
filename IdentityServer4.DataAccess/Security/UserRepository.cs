using IdentityServer4.DataModels;
using IdentityServer4.DataModels.Security;
using System.Collections.Generic;
using System.Linq;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace IdentityServer4.DataAccess.Security
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public UserRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ApplicationUser GetUser(string id)
        {
            var userFound = from user in _appDbContext.Users
                where user.Id == id
                select user;
            return userFound.ToList().FirstOrDefault();
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _appDbContext.Users;
        }

        public ApplicationUser AddUser(ApplicationUser user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
            return user;
        }

        public ApplicationUser UpdateUser(ApplicationUser user)
        {
            var updatedUser = _appDbContext.Attach(user);
            updatedUser.State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return user;
        }
    }
}

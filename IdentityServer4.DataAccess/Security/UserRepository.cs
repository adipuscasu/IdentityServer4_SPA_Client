﻿using IdentityServer4.DataModels.Security;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace IdentityServer4.DataAccess.Security
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public UserRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            var userFound = from user in _appDbContext.Users
                            where user.Id == id
                            select user;
            return await userFound
                .FirstOrDefaultAsync();
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            return _appDbContext.Users.AsNoTracking();
        }

        public async Task<ApplicationUser> AddUser(ApplicationUser user)
        {
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<ApplicationUser> UpdateUser(ApplicationUser user)
        {
            var updatedUser = _appDbContext.Attach(user);
            updatedUser.State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return user;
        }
    }
}

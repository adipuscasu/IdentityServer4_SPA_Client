using IdentityServer4.DataModels.Dto;
using IdentityServer4.DataModels.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer4.REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;


        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ApplicationUser> SaveUser(ApplicationUserDto user)
        {
            if(user == null)
                throw new ArgumentException(nameof(user));
            var result = await _userManager.CreateAsync(user, user.Password);

            if(!result.Succeeded)
                throw new ApplicationException("Registration failed");

            return user;
        }
    }
}
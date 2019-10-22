using IdentityServer4.DataAccess.Security;
using IdentityServer4.DataModels.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;


        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        
        [AllowAnonymous]
        [HttpPost("")]
        public ApplicationUser SaveUser()
        {
            var newUser = new ApplicationUser();
            newUser.Email = "test@test.test";
            newUser.UserName = "some_userName";
            _userRepository.AddUser(newUser);
            return newUser;
        }
    }
}
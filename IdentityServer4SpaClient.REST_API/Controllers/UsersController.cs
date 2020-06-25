using System.Threading.Tasks;
using IdentityServer4.DataAccess.Security;
using IdentityServer4.DataModels.Dto;
using IdentityServer4.DataModels.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4SpaClient.REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;


        public UsersController(
            UserManager<ApplicationUser> userManager,
            IUserRepository userRepository
            )
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }


        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> SaveUser(RegisterBindingModel user)
        {

            var result = await _userManager.CreateAsync(user, user.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            user.Password = null;
            user.ConfirmPassword = null;

            return Ok(user);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public System.Linq.IQueryable<ApplicationUser> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}
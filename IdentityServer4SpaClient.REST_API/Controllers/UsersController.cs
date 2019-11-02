using System.Threading.Tasks;
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


        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> SaveUser(RegisterBindingModel user)
        {
            if (!ModelState.IsValid)
            {
               return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(user, user.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            user.Password = null;
            user.ConfirmPassword = null;

            return Ok(user);
        }
    }
}
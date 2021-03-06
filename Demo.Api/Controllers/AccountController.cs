using System;
using System.Threading.Tasks;
using Demo.Api.Utils;
using Demo.Api.VM;
using Demo.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly UserManager<User> userManager;
        readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager,
                                SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] RegisterVM register)
        {
            var user = new User() {
                FirstName = register.FirstName,
                LastName = register.LastName,
                UserName = register.Email,
                Email = register.Email
            };

            var result = await userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
                return BadRequest(new ApiError { Message = "Registration failed."});

            return Ok(true);
        }

        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] CredentialsVM credentials)
        {
            var result = await signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, false, false);

            if (!result.Succeeded)
                return BadRequest(new ApiError { Message = "Login failed." });

            var user = await userManager.FindByEmailAsync(credentials.Email);

            TokenVM tokenVM = new TokenVM()
            {
                token = TokenUtility.CreateToken(user),
                expires_at = DateTimeOffset.UtcNow.AddMinutes(20).ToUnixTimeMilliseconds()
            };

            return Ok(tokenVM);
        }
    }
}
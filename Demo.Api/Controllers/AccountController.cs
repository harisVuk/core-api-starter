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
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager,
                                SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] RegisterVM register)
        {
            var user = new User() {
                FirstName = register.FirstName,
                LastName = register.LastName,
                UserName = register.Email,
                Email = register.Email
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
                return BadRequest(new ApiError { Message = "Registration failed."});

            return Ok(true);
        }

        [HttpPost]
        [Route("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] CredentialsVM credentials)
        {
            var result = await _signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, false, false);

            if (!result.Succeeded)
                return BadRequest(new ApiError { Message = "Login failed." });

            var user = await _userManager.FindByEmailAsync(credentials.Email);

            if(user == null)
                return BadRequest(new ApiError { Message = "Email not found." });

            TokenVM tokenVM = new TokenVM()
            {
                token = TokenUtility.CreateToken(user),
                expires_at = DateTimeOffset.UtcNow.AddMinutes(20).ToUnixTimeMilliseconds()
            };

            return Ok(tokenVM);
        }
    }
}
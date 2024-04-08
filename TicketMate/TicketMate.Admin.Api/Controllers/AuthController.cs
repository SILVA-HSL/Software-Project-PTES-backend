using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicketMate.Admin.Application.Dtos;
using TicketMate.Admin.Application.Services;

namespace TicketMate.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly UserManager<IdentityUser> userManager;
        public readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;

        }


        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestcsDto registerRequestcsDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestcsDto.Username,
                Email = registerRequestcsDto.Username
            };
            var result = await userManager.CreateAsync(identityUser, registerRequestcsDto.Password);
            if (result.Succeeded)
            {
                if (registerRequestcsDto.Roles != null && registerRequestcsDto.Roles.Any())
                {
                    result = await userManager.AddToRoleAsync(identityUser, registerRequestcsDto.Roles[0]);


                    if (result.Succeeded)
                    {
                        return Ok("User created");
                    }
                }
            }
            return Ok("User created");

        } 


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByNameAsync(loginRequestDto.Username);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    //get roles for this user
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        //create token
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new
                        {
                            JwtToken = jwtToken
                        };

                        return Ok(response);
                    }
                }
            }
            return BadRequest("Username or password incorrect");








        }

    }
}

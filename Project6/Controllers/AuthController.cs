using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project6.DTOs;
using Project6.Models;
using Project6.Services.Abstraction;
using Project6.Services.Implementation;

namespace Project6.Controllers
{
    [ApiController]
    [Authorize(Roles = "user, admin")]

    [Route("api/[Controller]/")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }
        //public AuthController() { }
        


        [HttpPost("/login-user")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserDTO loginUser)
        {
            try
            {
                var res = await userService.LoginUserAsync(loginUser);
                if (res == null)
                {
                    return Unauthorized("User is not authorized");
                }
                return Ok(new ApiResponse{ Token = res });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return Ok("User authorized");
        }

        [HttpDelete("/logout-user")]
        public async Task<IActionResult> LogoutUserAsync()
        {
            try
            {
               var resp = await userService.LogoutAsync();
                if (!resp)
                {
                    return BadRequest(new ApiResponse { Message = "Please try again" });
                }
                return Ok(new ApiResponse { Message = "Logged out successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                return BadRequest(new ApiResponse { Message = "Please try again" });
            }
        }
    }
}

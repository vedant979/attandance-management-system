using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Project6.DTOs;
using Project6.Models;
using Project6.Services.Abstraction;
using System.Security.Claims;

namespace Project6.Controllers
{
    [ApiController]
    [Route("api/[Controller]/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("/view-profile")]
        [Authorize]
        public async Task<IActionResult> GetUserData()
        {
            try
            {
                var resp = await userService.GetUserData();
                if (resp == null)
                {
                    return BadRequest(new { message = "Error while fetching user data!" });
                }
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                return BadRequest(new { message = "Error while fetching user data!" });
            }
        }

        [HttpPost("/attendance-punch-in")]
        [Authorize]
        public async Task<IActionResult> AttendancePunchInAsync()
        {
            try
            {
                var res = await userService.AttendancePunchIn();
                if (!res)
                {
                    return BadRequest(new ApiResponse { Message = "Server error" });
                }
                return Ok(new ApiResponse { Message = "Punched In successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                return BadRequest(new ApiResponse { Message = "Server Error" });
            }
        }
        [HttpPost("/attendance-punch-out")]
        [Authorize]
        public async Task<IActionResult> AttendancePunchOutAsync()
        {
            try
            {
                var res = await userService.AttendancePunchOut();
                if (!res)
                {
                    return BadRequest(new ApiResponse { Message = "Server error" });
                }
                return Ok(new ApiResponse { Message = "Punched Out successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                return BadRequest(new ApiResponse { Message = "Server Error" });
            }
        }

        [HttpPut("/update-user")]
        [Authorize]
        public async Task<IActionResult> UpdateUserData([FromBody] UpdateMemberDTO updateUser)
        {
            try
            {
                var response = await userService.updateUserDetailsAsync(updateUser);
                if (response == null)
                {
                    return BadRequest(new ApiResponse() { Message = "Update Failed" });
                }
                else
                {
                    return Ok(new ApiResponse() { Message = "Profile Updated!" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(new ApiResponse() { Message = "Update Failed" });

            }


        }

        [HttpPost("/recover-password")]
        [AllowAnonymous]
        public async Task<IActionResult> RecoverPassword([FromBody] RecoverPasswordDTO recoverPassword)
        {
            try
            {
                var res = await userService.RecoverPasswordAsync(recoverPassword);
                if (res)
                {
                    return Ok(new ApiResponse { Message = "Password is sent to your email." });
                }
                return BadRequest(new ApiResponse { Message = "User not found" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex.InnerException);
                return BadRequest(new ApiResponse { Message = "Failed to send password. Please try again." });
            }
        }

        [HttpPut("/reset-password")]
        [Authorize]
        public async Task<IActionResult> ResetPassword([FromBody] ChangeUserCredentialDTO changeUserCredential)
        {
            try
            {
                var response = await userService.ResetPasswordAsync(changeUserCredential);
                if (response)
                {
                    return Ok(new ApiResponse { Message = "Password was reset successfully!" });
                }
                return BadRequest(new ApiResponse { Message = "Password reset failed. Please try again!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex.InnerException);
                return BadRequest(new ApiResponse { Message = "Password reset failed. Please try again!" });
            }
        }

        [HttpGet("/get-attendance")]
        [Authorize]
        public async Task<IActionResult> GetAttendance()
        {
            try
            {
                var res = await userService.GetUsersAttendance(null);
                if (res.Count != 0)
                {
                    return Ok(res);
                }
                return BadRequest(new ApiResponse { Message = "Couldn't fetch details" });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                return BadRequest(new ApiResponse { Message = "Couldn't fetch details" });
            }
        }



        [HttpGet("/user/attendance/{month}")]
        [Authorize]
        public async Task<IActionResult> GetAttendanceReport(int month)
        {
            try
            {
                var res = await userService.GetUserReport(null, month);
                if (res.Count != 0)
                {
                    return Ok(res);
                }
                return BadRequest(new ApiResponse { Message = "Couldn't fetch details" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                return BadRequest(new ApiResponse { Message = "Couldn't fetch details, Server error" });
            }
        }

        [HttpPost("/user/attendance/regularize")]
        [Authorize]
        public async Task<IActionResult> PostRegularizeRequest([FromBody] RegularizationRequestDTO regularization)
        {
            try
            {
                var res = await userService.PostRegularizeRequest(null,regularization);
                if (res)
                {
                    return Ok(new ApiResponse { Message = "Request added" });
                }
                return BadRequest(new ApiResponse { Message = "Please try again later" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                return BadRequest(new ApiResponse { Message = "Please try again late, Server error" });
            }
        }
    }
}

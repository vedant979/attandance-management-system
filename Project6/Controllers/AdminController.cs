using Microsoft.AspNetCore.Mvc;
using Project6.DTOs;
using Project6.Models;
using Project6.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;


namespace Project6.Controllers
{

    [ApiController]
    [Authorize(Roles = "admin")]
    [Route("api/[Controller]/")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IUserService userService;

        public AdminController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("/register-user")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserDTO registerUser)
        {
            try
            {
                var result = await userService.RegisterUserAsync(registerUser);
                if (!result)
                {
                    return BadRequest(new ApiResponse { Message = "Registeration failed " });
                }
                else
                {
                    return Ok(new ApiResponse { Message = "User registered" });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(new ApiResponse { Message = "Registeration failed " });

            }

        }

        [HttpGet("/get-users")]
        public async Task<IActionResult> getAllUser()
        {
            try
            {
                var result = await userService.GetAllUserData();
                if (result.Count==0)
                {
                    return BadRequest(new ApiResponse { Message = "No users found" });
                }
                else
                {
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(new ApiResponse { Message = "No users found" });

            }
        }

        [HttpGet("/get-users-attendance")]
        public async Task<IActionResult> getUsersAttendance([FromQuery] int id)
        {
            try
            {
                List<UserAttendanceDto> result = await userService.GetUsersAttendance(id);
                if (result.Count == 0)
                {
                    return BadRequest(new ApiResponse { Message = "No data found" });
                }
                else
                {
                    Console.WriteLine(result);
                    return Ok( result );
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(new ApiResponse { Message = "No data found" });

            }
        }

        [HttpGet("/user/{EmployeeId}/month/{month}")]
        public async Task<IActionResult> GetUserAttendanceReport( int EmployeeId,int month)
        {
            try
            {
                List<UserAttendanceDto> result = await userService.GetUsersAttendance(EmployeeId);
                if (result.Count == 0)
                {
                    return BadRequest(new ApiResponse { Message = "No data found" });
                }
                else
                {
                    Console.WriteLine(result);
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(new ApiResponse { Message = "No data found" });

            }
        }


        [HttpPost("/user/{EmployeeId}/attendance/regularize")]
        public async Task<IActionResult> PostRegularizeRequest(int EmployeeId,[FromBody] RegularizationRequestDTO regularization)
        {
            try
            {
                var res = await userService.PostRegularizeRequest(EmployeeId,regularization);
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

        [HttpPut("/user/{empId}/regularization/request/{requestId}/update/status")]
        public async Task<IActionResult> UpdateRequestStatus(int empId, Guid requestId, [FromBody] bool isApproved)
        {
            try
            {
                var res = await userService.UpdateRequestStatus(empId, requestId, isApproved);
                if (res)
                {
                    return Ok(new ApiResponse { Message = "Status updated" });
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

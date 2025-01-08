using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project6.DTOs;
using Project6.Models;
using Project6.Services.Abstraction;

namespace Project6.Controllers
{
    [ApiController]
    [Route("api/[Controller]/")]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IUserService userService;

        public ContactController(IUserService userService)
        {
            this.userService = userService;
        }
        
        [HttpPost("/add-contact")]

        public async Task<IActionResult> AddContact([FromBody] AddContactDTO addContact)
        {
            try
            {
                var res = await userService.AddContactAsync(addContact);
                if (res)
                {
                    return Ok(new ApiResponse { Message = "Contact added successfully"});
                }
                return BadRequest(new ApiResponse { Message = "There was an error" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return BadRequest(new ApiResponse{ Message = "There was an error" });
        }

        [HttpPut("/update-contact")]

        public async Task<IActionResult> UpdateContactData([FromBody] UpdateContactDTO updateContact)
        {
            try
            {
                var res = await userService.UpdateContactAsync(updateContact);
                if (res)
                {
                    return Ok(new ApiResponse{ Message = "contact updated" });
                }
                return BadRequest(new ApiResponse{ Message = "Try again" });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return BadRequest(new ApiResponse { Message = "Try again" });
        }
    }
}

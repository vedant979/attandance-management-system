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
    public class AddressController : ControllerBase
    {
        private readonly IUserService userService;

        public AddressController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("/add-address")]
        public async Task<IActionResult> AddAddress([FromBody] AddressDTO addAddress)
        {
            try
            {
                //Address address = new Address();
                var response = await userService.addAddressDetailsAsync(addAddress);
                if (response == null)
                {
                    return BadRequest("User address not added");
                }
                return Ok("User address added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return BadRequest("User address not added");
        }

        [HttpPut("/update-address")]
        public async Task<IActionResult> UpdateAddressData([FromQuery] Guid id,[FromBody] UpdateAddressDTO updateAddress)
        {
            try
            {
                var response = await userService.updateAddressDetailsAsync(id,updateAddress);
                if (response == null)
                {
                    return BadRequest("User address not updated");
                }
                return Ok("User address updated!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return BadRequest("User address not updated");
        }

    }
}

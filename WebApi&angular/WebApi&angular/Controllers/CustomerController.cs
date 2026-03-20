using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBll;
using DTO.modelsDTO;

namespace WebApi_angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // מספק אוטומטית בדיקות בסיסיות של ModelState
    public class CustomerController : ControllerBase
    {
        IBllServecis t;

        public CustomerController(IBllServecis t)
        {
            this.t = t;
        }

        [HttpGet("ByEmail/{email}")]
        public async Task<CustomerDTO> GetCustomerByEmailAsync(string email)
        {
            return await t.GetCustomerByEmailAsync(email);
        }

        [HttpPost("ByCustomer")]
      
        public async Task<ActionResult<CustomerDTO>> RegisterAsync([FromBody] CustomerDTO dto)
        {
            // 1. בדיקת תקינות מודל מפורשת (למרות ש-[ApiController] עושה זאת אוטומטית)
            if (!ModelState.IsValid || dto == null)
            {
                // מחזיר 400 
                return BadRequest(ModelState);
            }

            var result = await t.RegisterAsync(dto);

            
            if (result == null)
                return Conflict("Email already exists"); // 409 Conflict

            // 3. הצלחה, מחזיר 200
            return Ok(result);
        }
    }
}
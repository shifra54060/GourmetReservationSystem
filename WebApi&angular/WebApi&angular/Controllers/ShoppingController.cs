using Bll;
using DTO.modelsDTO;
using IBll;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_angular.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        IBllServecis t;
        public ShoppingController(IBllServecis t)
        {
            this.t = t;

        }
        
        [HttpPost]
        public async Task AddShoppingAsync([FromBody] ShoppingDTO dto)
        {
                await t.AddShoppingAsync(dto);           

        }
    }
}
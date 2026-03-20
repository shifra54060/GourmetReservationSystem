using DTO.modelsDTO;
using IBll;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingDetailController : ControllerBase
    {
        IBllServecis t;
        public ShoppingDetailController(IBllServecis t)
        {
            this.t = t;

        }
        [HttpPost]
        public async Task AddShoppingDetailAsync(ShoppingDetailDTO dto)
        {
            await t.AddShoppingDetailAsync(dto);
        }
    }
}

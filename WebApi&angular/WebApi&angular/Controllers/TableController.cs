using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBll;
using DTO.modelsDTO;

namespace WebApi_angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        IBllServecis t;
        public TableController(IBllServecis t)
        {
            this.t = t;

        }
        [HttpGet]
        public async Task<List<TableDTO>> GetAllTablesAsync()
        {
            return await t.GetAllTablesAsync();
        }
        [HttpPost("ByStatusAndId")]
        public async Task<IActionResult> UpdateTableStatusAsync(int tableId, bool isOccupied)
        {
            await t.UpdateTableStatusAsync(tableId, isOccupied);
            return Ok();
        }

    }
}

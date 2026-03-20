using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBll;
using DTO.modelsDTO;

namespace WebApi_angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        IBllServecis t;
        public CategoryController(IBllServecis t)
        {
            this.t = t;

        }
        [HttpGet]
        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            return await t.GetCategoriesAsync();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBll;
using DTO.modelsDTO;
namespace WebApi_angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //מניעת תלות
        //נגדיר משתנה מסוג הממשק
        IBllServecis t;
        //נאתחל אותו בבנאי שמקבל מופע שלו בהזרקה
        public ProductsController(IBllServecis t)
        {
            this.t = t;

        }
        [HttpGet]
        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            return await t.GetAllProductsAsync();
        }
        [HttpGet("ByCategoryCode/{CategoryCode}")]
        public async Task<List<ProductDTO>> GetByCategoryCodeAsync(int CategoryCode)
        {
            return await t.GetByCategoryCodeAsync(CategoryCode);
        }
    }
}
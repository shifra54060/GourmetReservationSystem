using DTO.modelsDTO;
using IBll;
using IDal;

namespace Bll
{
    public class BllServices : IBllServecis
    {
        private readonly ITransaction t;

        public BllServices(ITransaction t)
        {
            this.t = t;
        }

        // כאן אנחנו מביאים את כל המוצרים
        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
           
            return await t.GetAllProductsAsync();
        }
        public async Task<List<ProductDTO>> GetByCategoryCodeAsync(int CategoryCode)
        {
            return await t.GetByCategoryCodeAsync(CategoryCode);
        }
        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            return await t.GetCategoriesAsync();
        }
        public async Task<CustomerDTO> GetCustomerByEmailAsync(string Email)
        {
            return await t.GetCustomerByEmailAsync(Email);
        }
        
        public async Task<CustomerDTO?> RegisterAsync(CustomerDTO dto)
        {
            var exist = await t.GetCustomerByEmailAsync(dto.Email);
            if (exist != null) 
                return null;
            await t.AddCustomerAsync(dto);
            return dto;
        }

        public async Task AddShoppingAsync(ShoppingDTO dto)
        {
        
                await t.AddShoppingAsync(dto);
                  
                }

        
        public async Task<List<TableDTO>> GetAllTablesAsync()
        {
            return await t.GetAllTablesAsync();
        }
        public async Task UpdateTableStatusAsync(int tableId, bool isOccupied)
        {
            await t.UpdateTableStatusAsync(tableId, isOccupied);

        }
        public async Task AddShoppingDetailAsync(ShoppingDetailDTO dto) {
            await t.AddShoppingDetailAsync(dto);
        }
    } }

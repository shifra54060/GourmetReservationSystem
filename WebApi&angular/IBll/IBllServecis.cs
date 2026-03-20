using DTO.modelsDTO;

namespace IBll
{
    public interface IBllServecis
    {
        Task<List<ProductDTO>> GetAllProductsAsync();
        Task<List<ProductDTO>> GetByCategoryCodeAsync(int CategoryCode);
        Task<List<CategoryDTO>> GetCategoriesAsync();
        Task<CustomerDTO> GetCustomerByEmailAsync(string email);
        Task<CustomerDTO?> RegisterAsync(CustomerDTO dto);
        Task<List<TableDTO>> GetAllTablesAsync();
        Task AddShoppingAsync(ShoppingDTO dto);
        Task AddShoppingDetailAsync(ShoppingDetailDTO dto);
        Task UpdateTableStatusAsync(int tableId, bool isOccupied);
    }
}

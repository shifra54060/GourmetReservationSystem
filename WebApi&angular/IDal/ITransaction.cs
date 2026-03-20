


using DTO.modelsDTO;
using System.Collections.Generic;
namespace IDal
{
    
    public  interface ITransaction
    {

        // Category
        //Task הוא הצהרה על פונקציה אסינכרונית ב־C#.
        Task<List<CategoryDTO>> GetCategoriesAsync();
        //Task<Category> GetCategoryByIdAsync(int id);
        //Task AddCategoryAsync(Category dto);
        //  Task UpdateCategoryAsync(Category dto);
        //Task DeleteCategoryAsync(int id);

        // Products
        Task<List<ProductDTO>> GetByCategoryCodeAsync(int CategoryCode);
        Task<List<ProductDTO>> GetAllProductsAsync();
        //Task<ProductDTO> GetProductByIdAsync(int id);
        //Task AddProductAsync(ProductDTO dto);
        //Task UpdateProductAsync(ProductDTO dto);
        //Task DeleteProductAsync(int id);

        // Customers
        //Task<List<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO?> GetCustomerByEmailAsync(string email);
        Task AddCustomerAsync(CustomerDTO dto);

        //Task UpdateCustomerAsync(CustomerDTO dto);
        //Task DeleteCustomerAsync(int id);

        // Shopping
        //Task<List<ShoppingDTO>> GetAllShoppingAsync();
        //Task<ShoppingDTO> GetShoppingByIdAsync(int id);
        Task AddShoppingAsync(ShoppingDTO dto);
        //Task UpdateShoppingAsync(ShoppingDTO dto);
        //Task DeleteShoppingAsync(int id);

        // ShoppingDetails
        //Task<List<ShoppingDetailDTO>> GetShoppingDetailsAsync(int shoppingCode);
        Task AddShoppingDetailAsync(ShoppingDetailDTO dto);
        //Task DeleteShoppingDetailAsync(int id);


        //Tabl
        Task<List<TableDTO>> GetAllTablesAsync();
            Task UpdateTableStatusAsync(int tableId, bool isOccupied);

    }
}





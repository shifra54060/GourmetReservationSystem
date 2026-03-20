using Dal.models;
using Dal.Converters;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDal;
using DTO.modelsDTO;


namespace Dal;
public class DalRepository : ITransaction
{
    private readonly FingerFoodStoreContext db;
    public DalRepository(FingerFoodStoreContext db)
    {
        this.db = db;

    }
    // ================== Products ==================
    public async Task<List<ProductDTO>> GetAllProductsAsync()
    {

        var tlist = await db.Products.Include(c => c.CategoryCodeNavigation).ToListAsync();


        return ConvertersProduct.ToDtoList(tlist);
    }

    public async Task<List<ProductDTO>> GetByCategoryCodeAsync(int CategoryCode)
    {
        var products = await db.Products
            .Include(c => c.CategoryCodeNavigation)
            .Where(c => c.CategoryCode == CategoryCode)
            .ToListAsync();


        return ConvertersProduct.ToDtoList(products);
    }
    //------------------------Category---------------------
    public async Task<List<CategoryDTO>> GetCategoriesAsync()
    {
        var category = await db.Categories.ToListAsync();


        return ConvertersCategory.ToDtoList(category);
    }
    //=============================Customer===========================
    public async Task<CustomerDTO?> GetCustomerByEmailAsync(string email)
    {
        var customer = await db.Customers
            .FirstOrDefaultAsync(c => c.Email == email);

        if (customer == null)
            return null;

        return ConvertersCustomer.ToDto(customer);
    }

    public async Task AddCustomerAsync(CustomerDTO dto)
    {

        var customer = ConvertersCustomer.ToEntity(dto);
        db.Customers.Add(customer);
        await db.SaveChangesAsync();
    }

    //============================Shopping============================
    public async Task AddShoppingAsync(ShoppingDTO dto)
    {

        var shopping = ConvertersShopping.ToEntity(dto);
        db.Shoppings.Add(shopping);
        await db.SaveChangesAsync();

    }
    //================ShoppingDetail=============================
    public async Task AddShoppingDetailAsync(ShoppingDetailDTO dto)
    {
        var shoppingDetail = ConvertersShoppingDetails.ToEntity(dto);
        db.ShoppingDetails.Add(shoppingDetail);
        await db.SaveChangesAsync();
    }

    // ================== Tables ==================

    public async Task<List<TableDTO>> GetAllTablesAsync()
    {

        var Tables = await db.Tables.ToListAsync();


        return ConvertersTable.ToDtoList(Tables);
    }

    public async Task UpdateTableStatusAsync(int tableId, bool isOccupied)
    {
        var table = await db.Tables.FirstOrDefaultAsync(t => t.TableId == tableId);
         if (table != null)
        {
            table.IsOccupied = isOccupied;
            await db.SaveChangesAsync();
        }

    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.modelsDTO;
using System.Collections.Generic;
namespace Dal.Converters
{
    internal class ConvertersProduct
    {
        public static ProductDTO ToDto(models.Product p)
        {
            if (p == null)
                return null;

            return new ProductDTO
            {
                ProductCode = p.ProductCode,
                Name = p.Name,
                Price = p.Price,
                UpdateDate = p.UpdateDate ?? DateOnly.MinValue,
                CategoryCode = p.CategoryCode,

                // --- שדות שחייבים להתווסף ---
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Size = p.Size,
                IsVegan = p.IsVegan,
                IsGlutenFree = p.IsGlutenFree,
                // -----------------------------

                CategoryName = p.CategoryCodeNavigation != null ? p.CategoryCodeNavigation.Name : ""
            };
        }

        public static List<ProductDTO> ToDtoList(List<models.Product> lt)
        {
            List<ProductDTO> lnew = new List<ProductDTO>();
            foreach (var item in lt)
            {
                lnew.Add(ToDto(item));
            }
            return lnew;
        }
    }
}

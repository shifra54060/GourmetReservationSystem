using DTO.modelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.models;
using System.Collections.Generic;

namespace Dal.Converters
{
    internal class ConvertersShoppingDetails
    {
        public static ShoppingDetailDTO ToDto(models.ShoppingDetail sd)
        {
            if (sd == null)
                return null;

            return new ShoppingDetailDTO
            {
                ShoppingDetailsCode = sd.ShoppingDetailsCode,
                ShoppingCode = sd.ShoppingCode,
                ProductCode = sd.ProductCode,
                Quantity = sd.Quantity,

                //     // מתוך ה-FK
                //     ProductName = sd.ProductCodeNavigation != null ? sd.ProductCodeNavigation.Name : "",
                // Price= sd.ProductCodeNavigation != null ? sd.ProductCodeNavigation.Price : 0,
                //Description= sd.ProductCodeNavigation != null ? sd.ProductCodeNavigation.Description : "",
                //     ImageUrl= sd.ProductCodeNavigation != null ? sd.ProductCodeNavigation.ImageUrl : "",
                //     OrderDate = sd.ShoppingCodeNavigation?.OrderDate ?? DateOnly.MinValue,


            };
        }
        public static ShoppingDetail ToEntity(ShoppingDetailDTO dto)
        {
            if (dto == null)
                return null;

            return new ShoppingDetail
            {
                ShoppingDetailsCode = dto.ShoppingDetailsCode,
                ShoppingCode = dto.ShoppingCode,
                ProductCode = dto.ProductCode,
                Quantity = dto.Quantity,

            };
        }

        public static List<ShoppingDetailDTO> ToDtoList(List<ShoppingDetail> entities)
        {
            var list = new List<ShoppingDetailDTO>();

            foreach (var item in entities)
                list.Add(ToDto(item));

            return list;
        }
        public static List<ShoppingDetail> ToEntityList(List<ShoppingDetailDTO> dtos)
        {
            var list = new List<ShoppingDetail>();
            foreach (var dto in dtos)
                list.Add(ToEntity(dto));

            return list;
        }
    }
}


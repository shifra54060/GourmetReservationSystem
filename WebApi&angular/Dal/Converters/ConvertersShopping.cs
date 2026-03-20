using Dal.models;
using DTO.modelsDTO;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dal.Converters
{
    internal class ConvertersShopping
    {

        public static Shopping ToEntity(ShoppingDTO dto)
        {
            if (dto == null)
                return null;

            return new Shopping
            {
                ShoppingCode = dto.ShoppingCode,
                OrderDate = dto.OrderDate,
                Remark = dto.Remark,
                TotalAmount = dto.TotalAmount ,
                CustomerCode = dto.CustomerCode,
              
            };
        }
        public static ShoppingDTO ToDto(models.Shopping s)
        {
            if (s == null)
                return null;

            return new ShoppingDTO
            {
                ShoppingCode = s.ShoppingCode,
                OrderDate = s.OrderDate,
                Remark = s.Remark,
                TotalAmount = s.TotalAmount ?? 0m,
                CustomerCode = s.CustomerCode,

                // מתוך ה-FK
                CustomerName = s.CustomerCodeNavigation != null ? s.CustomerCodeNavigation.FullName : ""
            };
        }
        // רשימה של Entity → רשימת DTO
        public static List<ShoppingDTO> ToDtoList(List<Shopping> Shopping)
        {
            var list = new List<ShoppingDTO>();
            foreach (var shopping in Shopping)
                list.Add(ToDto(shopping));

            return list;
        }

        // רשימה של DTO → רשימת Entity
        public static List<Shopping> ToEntityList(List<ShoppingDTO> dtos)
        {
            var list = new List<Shopping>();
            foreach (var dto in dtos)
                list.Add(ToEntity(dto));

            return list;
        }
    }
}

    
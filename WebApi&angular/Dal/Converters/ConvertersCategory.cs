using DTO.modelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    internal class ConvertersCategory
    {
        public static CategoryDTO ToDto(models.Category c)
        {
            if (c == null)
                return null;

            return new CategoryDTO
            {
                CategoryCode = c.CategoryCode,
                Name = c.Name
            };
        }

        public static List<CategoryDTO> ToDtoList(List<models.Category> lt)
        {
            List<CategoryDTO> lnew = new List<CategoryDTO>();
            foreach (var item in lt)
            {
                lnew.Add(ToDto(item));
            }
            return lnew;
        }
    }
}
    

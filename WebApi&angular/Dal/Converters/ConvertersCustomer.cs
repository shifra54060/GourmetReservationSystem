using Dal.models;
using DTO.modelsDTO;
using System.Collections.Generic;

namespace Dal.Converters
{
    public static class ConvertersCustomer
    {
        // DTO → ENTITY
        public static Customer ToEntity(CustomerDTO dto)
        {
            if (dto == null)
                return null;

            return new Customer
            {
                CustomerCode = dto.CustomerCode,
                FullName = dto.FullName,
                Email = dto.Email,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                BirthDate = dto.BirthDate
            };
        }

        // ENTITY → DTO
        public static CustomerDTO ToDto(Customer c)
        {
            if (c == null)
                return null;

            return new CustomerDTO
            {
                CustomerCode = c.CustomerCode,
                FullName = c.FullName,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
                Email = c.Email,
                BirthDate = c.BirthDate
            };
        }

        // ENTITY LIST → DTO LIST
        public static List<CustomerDTO> ToDtoList(List<Customer> entities)
        {
            var list = new List<CustomerDTO>();

            foreach (var item in entities)
                list.Add(ToDto(item));

            return list;
        }
    }
}

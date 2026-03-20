using Dal.models;
using DTO.modelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    internal class ConvertersTable
    {
        // Entity → DTO
      
        

           
    
        public static TableDTO ToDto(models.Table table)
        {
            if (table == null) return null!;

            return new TableDTO
            {
                TableId = table.TableId,
                TableNumber = table.TableNumber,
                Seats = table.Seats,
                IsOccupied = table.IsOccupied ?? false
            };
        }

    

        // DTO → Entity
        public static Table ToEntity(TableDTO dto)
        {
            if (dto == null) return null!;

            return new Table
            {
                TableId = dto.TableId,
                TableNumber = dto.TableNumber,
                Seats = dto.Seats,
                IsOccupied = dto.IsOccupied
            };
        }




        // רשימה של Entity → רשימת DTO
        public static List<TableDTO> ToDtoList(List<Table> tables)
        {
            var list = new List<TableDTO>();
            foreach (var table in tables)
                list.Add(ToDto(table));

            return list;
        }

        // רשימה של DTO → רשימת Entity
        public static List<Table> ToEntityList(List<TableDTO> dtos)
        {
            var list = new List<Table>();
            foreach (var dto in dtos)
                list.Add(ToEntity(dto));

            return list;
        }
    }
}


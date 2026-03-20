using System;
using System.Collections.Generic;

namespace DTO.modelsDTO;

public partial class ProductDTO
{
    public int ProductCode { get; set; }
    public string Name { get; set; } = null!;
public DateOnly UpdateDate { get; set; }    
    public int CategoryCode { get; set; }
    public string CategoryName { get; set; }=null!;
   public string Description { get; set; } = null!;
    public int Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string? Size { get; set; }
    public bool? IsVegan { get; set; }
    public bool? IsGlutenFree { get; set; }
}

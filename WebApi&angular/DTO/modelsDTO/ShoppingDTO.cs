using System;
using System.Collections.Generic;

namespace DTO.modelsDTO;

public partial class ShoppingDTO
{
    public int ShoppingCode { get; set; }

    public int CustomerCode { get; set; }
    public string? CustomerName { get; set; }
    public DateOnly OrderDate { get; set; }

    public string? Remark { get; set; }
    public decimal TotalAmount { get; set; }



}

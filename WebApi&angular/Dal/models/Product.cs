using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Product
{
    public int ProductCode { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryCode { get; set; }

    public string Description { get; set; } = null!;

    public int Price { get; set; }

    public string ImageUrl { get; set; } = null!;

    public DateOnly? UpdateDate { get; set; }

    public string? Size { get; set; }

    public bool? IsGlutenFree { get; set; }

    public bool? IsVegan { get; set; }

    public virtual Category CategoryCodeNavigation { get; set; } = null!;

    public virtual ICollection<ShoppingDetail> ShoppingDetails { get; set; } = new List<ShoppingDetail>();
}

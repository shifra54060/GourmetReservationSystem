using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Category
{
    public int CategoryCode { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

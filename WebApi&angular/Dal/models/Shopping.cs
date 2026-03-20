using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Shopping
{
    public int ShoppingCode { get; set; }

    public int CustomerCode { get; set; }

    public DateOnly OrderDate { get; set; }

    public string? Remark { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Customer CustomerCodeNavigation { get; set; } = null!;

    public virtual ICollection<ShoppingDetail> ShoppingDetails { get; set; } = new List<ShoppingDetail>();
}

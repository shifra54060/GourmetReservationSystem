using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class ShoppingDetail
{
    public int ShoppingDetailsCode { get; set; }

    public int ShoppingCode { get; set; }

    public int ProductCode { get; set; }

    public int Quantity { get; set; }

    public virtual Product ProductCodeNavigation { get; set; } = null!;

    public virtual Shopping ShoppingCodeNavigation { get; set; } = null!;
}

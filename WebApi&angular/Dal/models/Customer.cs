using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Customer
{
    public int CustomerCode { get; set; }

    public string FullName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Shopping> Shoppings { get; set; } = new List<Shopping>();
}

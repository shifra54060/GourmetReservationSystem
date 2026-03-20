using System;
using System.Collections.Generic;

namespace DTO.modelsDTO;

public partial class CustomerDTO
{
    public int CustomerCode { get; set; }

    public string FullName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string Email { get; set; } = null!;
    public string Address { get; set; }
    public DateOnly? BirthDate { get; set; }


}

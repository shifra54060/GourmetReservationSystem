using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Table
{
    public int TableId { get; set; }

    public int TableNumber { get; set; }

    public int Seats { get; set; }

    public bool? IsOccupied { get; set; }
}

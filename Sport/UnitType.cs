using System;
using System.Collections.Generic;

namespace Sport;

public partial class UnitType
{
    public int UnitTypeId { get; set; }

    public string? UnitTypeName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

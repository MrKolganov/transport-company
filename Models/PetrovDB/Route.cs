using System;
using System.Collections.Generic;

namespace KolganovPS.Models.PetrovDB;

public partial class Route
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Range { get; set; }

    public int? NumberDaysRoad { get; set; }

    public int CarID { get; set; }

    public virtual Car Car { get; set; } = null!;
}

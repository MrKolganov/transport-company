using System;
using System.Collections.Generic;

namespace KolganovPS.Models.PetrovDB;

public partial class Driver
{
    public int Id { get; set; }

    public string? FIO { get; set; }

    public DateOnly? StartDate { get; set; }

    public int CarsID { get; set; }

    public virtual Car Cars { get; set; } = null!;
}

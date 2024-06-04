using System;
using System.Collections.Generic;

namespace KolganovPS.Models.PetrovDB;

public partial class Sending
{
    public int Id { get; set; }

    public string? From { get; set; }

    public string? Where { get; set; }

    public int CargoID { get; set; }

    public virtual Cargo Cargo { get; set; } = null!;
}

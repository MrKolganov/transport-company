using System;
using System.Collections.Generic;

namespace KolganovPS.Models.PetrovDB;

public partial class Client
{
    public int Id { get; set; }

    public string? FIO { get; set; }

    public string? Cargo { get; set; }

    public DateOnly? DateDispatch { get; set; }

    public virtual ICollection<Cargo> Cargos { get; } = new List<Cargo>();
}

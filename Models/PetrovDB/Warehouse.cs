using System;
using System.Collections.Generic;

namespace KolganovPS.Models.PetrovDB;

public partial class Warehouse
{
    public int ID_ { get; set; }

    public decimal? Size { get; set; }

    public virtual ICollection<Cargo> Cargos { get; } = new List<Cargo>();
}

using System;
using System.Collections.Generic;

namespace KolganovPS.Models.PetrovDB;

public partial class Cargo
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Weight { get; set; }

    public string? Destination { get; set; }

    public int ClientID { get; set; }

    public int WarehouseID { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Sending> Sendings { get; } = new List<Sending>();

    public virtual Warehouse Warehouse { get; set; } = null!;
}

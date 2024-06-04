using System;
using System.Collections.Generic;

namespace KolganovPS.Models.PetrovDB;

public partial class Car
{
    public int Id { get; set; }

    public string? NumberCar { get; set; }

    public int Driver { get; set; }

    public virtual ICollection<Driver> Drivers { get; } = new List<Driver>();

    public virtual ICollection<Route> Routes { get; } = new List<Route>();
}

using System;
using System.Collections.Generic;

namespace KolganovPS.Models.PetrovDB;

public partial class Client_Route
{
    public int Client_Id { get; set; }

    public int Route_Id { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Route Route { get; set; } = null!;
}

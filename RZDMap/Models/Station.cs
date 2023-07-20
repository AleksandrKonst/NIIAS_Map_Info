using System;
using System.Collections.Generic;

namespace RZDMap.Models;

public partial class Station
{
    public int Id { get; set; }

    public int Esr { get; set; }

    public long OsmId { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public string Name { get; set; } = null!;
}

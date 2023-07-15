namespace RZDMap.Models;

public partial class Station
{
    public int Esr { get; set; }

    public long OsmId { get; set; }

    public double? Lat { get; set; }

    public double? Lon { get; set; }

    public string Name { get; set; }

    public int? User { get; set; }
}

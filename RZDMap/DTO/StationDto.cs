using System.ComponentModel.DataAnnotations;

namespace RZDMapRailwaysApi.DTO;

public class StationDto
{
    [Required]
    public int Esr { get; set; }

    [Required]
    public long OsmId { get; set; }
    
    public double Lat { get; set; }
    
    public double Lon { get; set; }
    
    public string Name { get; set; }

    public int? User { get; set; }
}
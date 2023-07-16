using System.ComponentModel.DataAnnotations;

namespace RZDMap.DTO;

public class StationDto
{
    [Required]
    public int Esr { get; set; }

    [Required]
    public long OsmId { get; set; }
    
    [Required]
    public double Lat { get; set; }
    
    [Required]
    public double Lon { get; set; }
    
    [Required]
    public string Name { get; set; }

    public int? User { get; set; }
}
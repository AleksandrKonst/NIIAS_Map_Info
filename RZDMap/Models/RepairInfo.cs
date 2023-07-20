using System;
using System.Collections.Generic;

namespace RZDMap.Models;

public partial class RepairInfo
{
    public int? Stan1Id { get; set; }

    public int? Stan2Id { get; set; }

    public string? TrackName { get; set; }

    public DateTime? DtNdP { get; set; }

    public DateTime? DtKdP { get; set; }

    public int? IdWr { get; set; }

    public int? RepairId { get; set; }

    public string? RepairName { get; set; }

    public int? IdWork { get; set; }

    public string? WorkName { get; set; }
}

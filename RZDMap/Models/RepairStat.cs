using System;
using System.Collections.Generic;

namespace RZDMap.Models;

public partial class RepairStat
{
    public string? ObjId { get; set; }

    public decimal? MonthN { get; set; }

    public decimal? YearN { get; set; }

    public int? RepairId { get; set; }

    public long? WorkQuant { get; set; }
}

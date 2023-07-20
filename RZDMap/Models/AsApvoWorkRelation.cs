using System;
using System.Collections.Generic;

namespace RZDMap.Models;

public partial class AsApvoWorkRelation
{
    public int? IdWr { get; set; }

    public int? InfraObjId { get; set; }

    public int? SlId { get; set; }

    public int? RepairId { get; set; }

    public int? EiId { get; set; }

    public int? IdWork { get; set; }

    public int? IdGr1 { get; set; }

    public DateTime? DateNd { get; set; }

    public DateTime? DateKd { get; set; }

    public string? CorTip { get; set; }

    public int? WrWeight { get; set; }

    public string? Comment { get; set; }

    public bool? RcsRequired { get; set; }
}

using System;
using System.Collections.Generic;

namespace RZDMap.Models;

public partial class Ic00PeregM
{
    public int PeregMsId { get; set; }

    public int? UpId { get; set; }

    public int Stan1Id { get; set; }

    public int Stan2Id { get; set; }

    public decimal? Expl { get; set; }

    public char CorTip { get; set; }

    public DateOnly DateNd { get; set; }

    public DateOnly DateKd { get; set; }

    public DateTime? CorTime { get; set; }

    public int? OperId { get; set; }

    public short? ReplFl { get; set; }

    public short? Chet { get; set; }
}

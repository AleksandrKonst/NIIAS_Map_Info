using System;
using System.Collections.Generic;

namespace RZDMap.Models;

public partial class Ic00Stan
{
    public int StanId { get; set; }

    public int? DorKod { get; set; }

    public int? PredId { get; set; }

    public int? OkatoId { get; set; }

    public int? StKod { get; set; }

    public string? Vname { get; set; }

    public string? Name { get; set; }

    public int? StanTipId { get; set; }

    public string? CorTip { get; set; }

    public DateTime? DateNd { get; set; }

    public DateTime? DateKd { get; set; }

    public string? CorTime { get; set; }

    public int? OperId { get; set; }

    public string? ReplFl { get; set; }

    public string? StKodKr { get; set; }

    public string? Mnem { get; set; }
}

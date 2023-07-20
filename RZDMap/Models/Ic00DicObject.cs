using System;
using System.Collections.Generic;

namespace RZDMap.Models;

public partial class Ic00DicObject
{
    public int? ObjectId { get; set; }

    public int? ClassId { get; set; }

    public int? ObjectKod { get; set; }

    public string? ObjectKodstr { get; set; }

    public string? ObjectVname { get; set; }

    public string? ObjectName { get; set; }

    public string? ObjectSname { get; set; }

    public string? Refer { get; set; }

    public string? S1 { get; set; }

    public int? I1 { get; set; }

    public string? Komm { get; set; }

    public string? CorTip { get; set; }

    public DateOnly? DateNd { get; set; }

    public DateOnly? DateKd { get; set; }

    public DateTime? CorTime { get; set; }

    public int? OperId { get; set; }

    public int? ReplFl { get; set; }
}

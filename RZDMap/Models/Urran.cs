using System;
using System.Collections.Generic;

namespace RZDMap.Models;

public partial class Urran
{
    public int? Year { get; set; }

    public string? Pch { get; set; }

    public int? Idstation1 { get; set; }

    public int? Idstation2 { get; set; }

    public string? Name { get; set; }

    public int? Track { get; set; }

    public int? Kmn { get; set; }

    public int? Pkn { get; set; }

    public int? Kmk { get; set; }

    public int? Pkk { get; set; }

    public string? Length { get; set; }

    public string? Classgroupcategory { get; set; }

    public string? Gruzonapryazhennost { get; set; }

    public int? Speedpass { get; set; }

    public int? Speedfreight { get; set; }

    public string? NormativetonnageKr { get; set; }

    public int? NormativeyearsKr { get; set; }

    public string? NormativetonnageSr { get; set; }

    public string? NormativeyearsSr { get; set; }

    public string? Tonngefact { get; set; }

    public int? Servicelife { get; set; }

    public string? PercentServiceLife { get; set; }

    public int? LastKrYear { get; set; }

    public string? LastRepairType { get; set; }

    public string? LastRepairYear { get; set; }

    public string? Railtype { get; set; }

    public string? Sleeperstype { get; set; }

    public string? Anker { get; set; }

    public string? Rodbalasta { get; set; }

    public string? Razdsloy { get; set; }

    public int? Vihodfact { get; set; }

    public int? Vihodnorm { get; set; }

    public string? Vihodbsmalli { get; set; }

    public string? Vihodk { get; set; }

    public string? Vihodbbigi { get; set; }

    public int? Defectfact { get; set; }

    public int? Defectnorm { get; set; }

    public int? Defectbsmalli { get; set; }

    public string? Defectk { get; set; }

    public int? Defectbbigi { get; set; }

    public string? Skrepfact { get; set; }

    public string? Skrepnorm { get; set; }

    public string? Skrepbsmalli { get; set; }

    public string? Skrepk { get; set; }

    public string? Skrepbbigi { get; set; }

    public string? Vspleskfact { get; set; }

    public string? Vsplesknorm { get; set; }

    public string? Vspleskbsmalli { get; set; }

    public string? Vspleskk { get; set; }

    public string? Vspleskbbigi { get; set; }

    public int? Ballastfact { get; set; }

    public int? Ballastnorm { get; set; }

    public int? Ballastbsmalli { get; set; }

    public string? Ballastk { get; set; }

    public string? Ballastbbigi { get; set; }

    public int? Woodfact { get; set; }

    public int? Woodnorm { get; set; }

    public int? Woodbsmalli { get; set; }

    public string? Woodk { get; set; }

    public string? Woodbbigi { get; set; }

    public string? Intensivnots3katFact { get; set; }

    public string? Intensivnots3katNorm { get; set; }

    public string? Avgrepairtime3fact { get; set; }

    public string? Avgrepairtime3norm { get; set; }

    public string? Readykoef3norm { get; set; }

    public string? Readykoef3fact { get; set; }

    public string? Lambdaopasn3norm { get; set; }

    public string? Lambdaopasn3fact { get; set; }

    public int? OtsCount { get; set; }

    public int? OtsHours { get; set; }

    public int? Countotstup { get; set; }

    public string? Predotkazindex { get; set; }

    public string? Zatratinas { get; set; }

    public string? Koefrashodkr { get; set; }

    public string? Koefrashodkrs { get; set; }

    public string? Koefrashod { get; set; }

    public string? Koeftehsost { get; set; }

    public string? Ostatresurs { get; set; }

    public int? Ostatresursyear { get; set; }

    public string? Remresurs { get; set; }

    public int? Remresursyear { get; set; }

    public string? Proptonnage { get; set; }

    public int? Progyear { get; set; }

    public int? Yearprognoz { get; set; }

    public string? Vidremont { get; set; }

    public virtual Ic00Stan? Idstation1Navigation { get; set; }

    public virtual Ic00Stan? Idstation2Navigation { get; set; }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RZDMap.Models;

public partial class PostgresContext : IdentityDbContext<IdentityUser>
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsApvoOkna> AsApvoOknas { get; set; }

    public virtual DbSet<AsApvoWorkRelation> AsApvoWorkRelations { get; set; }

    public virtual DbSet<Ic00DicObject> Ic00DicObjects { get; set; }

    public virtual DbSet<Ic00PeregM> Ic00PeregMs { get; set; }

    public virtual DbSet<Ic00Stan> Ic00Stans { get; set; }

    public virtual DbSet<Icd1Work> Icd1Works { get; set; }

    public virtual DbSet<RepairInfo> RepairInfos { get; set; }

    public virtual DbSet<RepairStat> RepairStats { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<StationLine> StationLines { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<Urran> Urrans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=postgresql.niias-team.ru;Port=5432;Database=postgres;User Id=student;Password=s123!!!");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsApvoOkna>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("as_apvo_okna");

            entity.Property(e => e.Anker)
                .HasMaxLength(50)
                .HasColumnName("anker");
            entity.Property(e => e.Ballastbbigi)
                .HasMaxLength(50)
                .HasColumnName("ballastbbigi");
            entity.Property(e => e.Ballastbsmalli).HasColumnName("ballastbsmalli");
            entity.Property(e => e.Ballastfact).HasColumnName("ballastfact");
            entity.Property(e => e.Ballastk)
                .HasMaxLength(50)
                .HasColumnName("ballastk");
            entity.Property(e => e.Ballastnorm).HasColumnName("ballastnorm");
            entity.Property(e => e.Classgroupcategory)
                .HasMaxLength(50)
                .HasColumnName("classgroupcategory");
            entity.Property(e => e.Defectbbigi).HasColumnName("defectbbigi");
            entity.Property(e => e.Defectbsmalli).HasColumnName("defectbsmalli");
            entity.Property(e => e.Defectfact).HasColumnName("defectfact");
            entity.Property(e => e.Defectk)
                .HasMaxLength(50)
                .HasColumnName("defectk");
            entity.Property(e => e.Defectnorm).HasColumnName("defectnorm");
            entity.Property(e => e.DtKdP)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_kd_p");
            entity.Property(e => e.DtNdP)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_nd_p");
            entity.Property(e => e.Gruzonapryazhennost)
                .HasMaxLength(50)
                .HasColumnName("gruzonapryazhennost");
            entity.Property(e => e.IdWr).HasColumnName("id_wr");
            entity.Property(e => e.IdZ).HasColumnName("id_z");
            entity.Property(e => e.Idstation1).HasColumnName("idstation1");
            entity.Property(e => e.Idstation2).HasColumnName("idstation2");
            entity.Property(e => e.Intensivnots3katNorm)
                .HasMaxLength(50)
                .HasColumnName("intensivnots3kat_norm");
            entity.Property(e => e.Kmk).HasColumnName("kmk");
            entity.Property(e => e.Kmn).HasColumnName("kmn");
            entity.Property(e => e.LastKrYear).HasColumnName("last_kr_year");
            entity.Property(e => e.LastRepairType)
                .HasMaxLength(50)
                .HasColumnName("last_repair_type");
            entity.Property(e => e.LastRepairYear)
                .HasMaxLength(50)
                .HasColumnName("last_repair_year");
            entity.Property(e => e.Length)
                .HasMaxLength(50)
                .HasColumnName("length");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Nom)
                .HasMaxLength(4)
                .HasColumnName("nom");
            entity.Property(e => e.NormativetonnageKr)
                .HasMaxLength(50)
                .HasColumnName("normativetonnage_kr");
            entity.Property(e => e.NormativetonnageSr)
                .HasMaxLength(50)
                .HasColumnName("normativetonnage_sr");
            entity.Property(e => e.NormativeyearsKr).HasColumnName("normativeyears_kr");
            entity.Property(e => e.NormativeyearsSr)
                .HasMaxLength(50)
                .HasColumnName("normativeyears_sr");
            entity.Property(e => e.Pch)
                .HasMaxLength(50)
                .HasColumnName("pch");
            entity.Property(e => e.PercentServiceLife)
                .HasMaxLength(50)
                .HasColumnName("percent_service_life");
            entity.Property(e => e.Pkk).HasColumnName("pkk");
            entity.Property(e => e.Pkn).HasColumnName("pkn");
            entity.Property(e => e.PredId).HasColumnName("pred_id");
            entity.Property(e => e.Railtype)
                .HasMaxLength(50)
                .HasColumnName("railtype");
            entity.Property(e => e.Razdsloy)
                .HasMaxLength(50)
                .HasColumnName("razdsloy");
            entity.Property(e => e.Rodbalasta)
                .HasMaxLength(50)
                .HasColumnName("rodbalasta");
            entity.Property(e => e.Servicelife).HasColumnName("servicelife");
            entity.Property(e => e.Skrepbbigi)
                .HasMaxLength(50)
                .HasColumnName("skrepbbigi");
            entity.Property(e => e.Skrepbsmalli)
                .HasMaxLength(50)
                .HasColumnName("skrepbsmalli");
            entity.Property(e => e.Skrepfact)
                .HasMaxLength(50)
                .HasColumnName("skrepfact");
            entity.Property(e => e.Skrepk)
                .HasMaxLength(50)
                .HasColumnName("skrepk");
            entity.Property(e => e.Skrepnorm)
                .HasMaxLength(50)
                .HasColumnName("skrepnorm");
            entity.Property(e => e.Sleeperstype)
                .HasMaxLength(50)
                .HasColumnName("sleeperstype");
            entity.Property(e => e.Speedfreight).HasColumnName("speedfreight");
            entity.Property(e => e.Speedpass).HasColumnName("speedpass");
            entity.Property(e => e.Stan1Id).HasColumnName("stan1_id");
            entity.Property(e => e.Stan2Id).HasColumnName("stan2_id");
            entity.Property(e => e.Tip).HasColumnName("tip");
            entity.Property(e => e.Tonngefact)
                .HasMaxLength(50)
                .HasColumnName("tonngefact");
            entity.Property(e => e.Track).HasColumnName("track");
            entity.Property(e => e.Vihodbbigi)
                .HasMaxLength(50)
                .HasColumnName("vihodbbigi");
            entity.Property(e => e.Vihodbsmalli)
                .HasMaxLength(50)
                .HasColumnName("vihodbsmalli");
            entity.Property(e => e.Vihodfact).HasColumnName("vihodfact");
            entity.Property(e => e.Vihodk)
                .HasMaxLength(50)
                .HasColumnName("vihodk");
            entity.Property(e => e.Vihodnorm).HasColumnName("vihodnorm");
            entity.Property(e => e.Vspleskbbigi)
                .HasMaxLength(50)
                .HasColumnName("vspleskbbigi");
            entity.Property(e => e.Vspleskbsmalli)
                .HasMaxLength(50)
                .HasColumnName("vspleskbsmalli");
            entity.Property(e => e.Vspleskfact)
                .HasMaxLength(50)
                .HasColumnName("vspleskfact");
            entity.Property(e => e.Vspleskk)
                .HasMaxLength(50)
                .HasColumnName("vspleskk");
            entity.Property(e => e.Vsplesknorm)
                .HasMaxLength(50)
                .HasColumnName("vsplesknorm");
            entity.Property(e => e.Woodbbigi)
                .HasMaxLength(50)
                .HasColumnName("woodbbigi");
            entity.Property(e => e.Woodbsmalli).HasColumnName("woodbsmalli");
            entity.Property(e => e.Woodfact).HasColumnName("woodfact");
            entity.Property(e => e.Woodk)
                .HasMaxLength(50)
                .HasColumnName("woodk");
            entity.Property(e => e.Woodnorm).HasColumnName("woodnorm");
        });

        modelBuilder.Entity<AsApvoWorkRelation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("as_apvo_work_relations");

            entity.Property(e => e.Comment)
                .HasMaxLength(256)
                .HasColumnName("COMMENT");
            entity.Property(e => e.CorTip)
                .HasMaxLength(2)
                .HasColumnName("cor_tip");
            entity.Property(e => e.DateKd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_kd");
            entity.Property(e => e.DateNd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_nd");
            entity.Property(e => e.EiId).HasColumnName("ei_id");
            entity.Property(e => e.IdGr1).HasColumnName("id_gr1");
            entity.Property(e => e.IdWork).HasColumnName("id_work");
            entity.Property(e => e.IdWr).HasColumnName("id_wr");
            entity.Property(e => e.InfraObjId).HasColumnName("infra_obj_id");
            entity.Property(e => e.RcsRequired).HasColumnName("rcs_required");
            entity.Property(e => e.RepairId).HasColumnName("repair_id");
            entity.Property(e => e.SlId).HasColumnName("sl_id");
            entity.Property(e => e.WrWeight).HasColumnName("wr_weight");
        });

        modelBuilder.Entity<Ic00DicObject>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ic00_dic_objects");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.CorTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("cor_time");
            entity.Property(e => e.CorTip)
                .HasMaxLength(2)
                .HasColumnName("cor_tip");
            entity.Property(e => e.DateKd).HasColumnName("date_kd");
            entity.Property(e => e.DateNd).HasColumnName("date_nd");
            entity.Property(e => e.I1).HasColumnName("i1");
            entity.Property(e => e.Komm)
                .HasMaxLength(200)
                .HasColumnName("komm");
            entity.Property(e => e.ObjectId).HasColumnName("object_id");
            entity.Property(e => e.ObjectKod).HasColumnName("object_kod");
            entity.Property(e => e.ObjectKodstr)
                .HasMaxLength(128)
                .HasColumnName("object_kodstr");
            entity.Property(e => e.ObjectName)
                .HasMaxLength(512)
                .HasColumnName("object_name");
            entity.Property(e => e.ObjectSname)
                .HasMaxLength(128)
                .HasColumnName("object_sname");
            entity.Property(e => e.ObjectVname)
                .HasMaxLength(512)
                .HasColumnName("object_vname");
            entity.Property(e => e.OperId).HasColumnName("oper_id");
            entity.Property(e => e.Refer)
                .HasMaxLength(100)
                .HasColumnName("refer");
            entity.Property(e => e.ReplFl).HasColumnName("repl_fl");
            entity.Property(e => e.S1)
                .HasMaxLength(16)
                .HasColumnName("s1");
        });

        modelBuilder.Entity<Ic00PeregM>(entity =>
        {
            entity.HasKey(e => e.PeregMsId).HasName("ic00_pereg_ms_pk");

            entity.ToTable("ic00_pereg_ms");

            entity.Property(e => e.PeregMsId)
                .ValueGeneratedNever()
                .HasColumnName("pereg_ms_id");
            entity.Property(e => e.Chet).HasColumnName("chet");
            entity.Property(e => e.CorTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("cor_time");
            entity.Property(e => e.CorTip)
                .HasMaxLength(1)
                .HasDefaultValueSql("'I'::bpchar")
                .HasColumnName("cor_tip");
            entity.Property(e => e.DateKd)
                .HasDefaultValueSql("'9999-12-31'::date")
                .HasColumnName("date_kd");
            entity.Property(e => e.DateNd)
                .HasDefaultValueSql("'2000-01-01'::date")
                .HasColumnName("date_nd");
            entity.Property(e => e.Expl)
                .HasPrecision(6, 3)
                .HasColumnName("expl");
            entity.Property(e => e.OperId).HasColumnName("oper_id");
            entity.Property(e => e.ReplFl).HasColumnName("repl_fl");
            entity.Property(e => e.Stan1Id).HasColumnName("stan1_id");
            entity.Property(e => e.Stan2Id).HasColumnName("stan2_id");
            entity.Property(e => e.UpId).HasColumnName("up_id");
        });

        modelBuilder.Entity<Ic00Stan>(entity =>
        {
            entity.HasKey(e => e.StanId).HasName("ic00_stan_pk");

            entity.ToTable("ic00_stan");

            entity.Property(e => e.StanId)
                .ValueGeneratedNever()
                .HasColumnName("stan_id");
            entity.Property(e => e.CorTime)
                .HasMaxLength(32)
                .HasColumnName("cor_time");
            entity.Property(e => e.CorTip)
                .HasMaxLength(2)
                .HasColumnName("cor_tip");
            entity.Property(e => e.DateKd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_kd");
            entity.Property(e => e.DateNd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_nd");
            entity.Property(e => e.DorKod).HasColumnName("dor_kod");
            entity.Property(e => e.Mnem)
                .HasMaxLength(100)
                .HasColumnName("mnem");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
            entity.Property(e => e.OkatoId).HasColumnName("okato_id");
            entity.Property(e => e.OperId).HasColumnName("oper_id");
            entity.Property(e => e.PredId).HasColumnName("pred_id");
            entity.Property(e => e.ReplFl)
                .HasMaxLength(5)
                .HasColumnName("repl_fl");
            entity.Property(e => e.StKod).HasColumnName("st_kod");
            entity.Property(e => e.StKodKr)
                .HasMaxLength(10)
                .HasColumnName("st_kod_kr");
            entity.Property(e => e.StanTipId).HasColumnName("stan_tip_id");
            entity.Property(e => e.Vname)
                .HasMaxLength(256)
                .HasColumnName("vname");
        });

        modelBuilder.Entity<Icd1Work>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("icd1_work");

            entity.Property(e => e.CorTip).HasColumnName("cor_tip");
            entity.Property(e => e.DateKd).HasColumnName("date_kd");
            entity.Property(e => e.DateNd).HasColumnName("date_nd");
            entity.Property(e => e.IdWork).HasColumnName("id_work");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Sname).HasColumnName("sname");
        });

        modelBuilder.Entity<RepairInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("repair_info");

            entity.Property(e => e.DtKdP)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_kd_p");
            entity.Property(e => e.DtNdP)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_nd_p");
            entity.Property(e => e.IdWork).HasColumnName("id_work");
            entity.Property(e => e.IdWr).HasColumnName("id_wr");
            entity.Property(e => e.RepairId).HasColumnName("repair_id");
            entity.Property(e => e.RepairName)
                .HasMaxLength(512)
                .HasColumnName("repair_name");
            entity.Property(e => e.Stan1Id).HasColumnName("stan1_id");
            entity.Property(e => e.Stan2Id).HasColumnName("stan2_id");
            entity.Property(e => e.TrackName).HasColumnName("track_name");
            entity.Property(e => e.WorkName).HasColumnName("work_name");
        });

        modelBuilder.Entity<RepairStat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("repair_stat");

            entity.Property(e => e.MonthN).HasColumnName("month_n");
            entity.Property(e => e.ObjId).HasColumnName("obj_id");
            entity.Property(e => e.RepairId).HasColumnName("repair_id");
            entity.Property(e => e.WorkQuant).HasColumnName("work_quant");
            entity.Property(e => e.YearN).HasColumnName("year_n");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("stations_pkey");

            entity.ToTable("stations");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Esr).HasColumnName("esr");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.OsmId).HasColumnName("osm_id");
        });

        modelBuilder.Entity<StationLine>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("station_line");

            entity.Property(e => e.LatSt1).HasColumnName("lat_st1");
            entity.Property(e => e.LatSt2).HasColumnName("lat_st2");
            entity.Property(e => e.LonSt1).HasColumnName("lon_st1");
            entity.Property(e => e.LonSt2).HasColumnName("lon_st2");
            entity.Property(e => e.Stan1Id).HasColumnName("stan1_id");
            entity.Property(e => e.Stan2Id).HasColumnName("stan2_id");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => new { e.Stan1Id, e.Stan2Id }).HasName("tracks_pkey");

            entity.ToTable("tracks");

            entity.Property(e => e.Stan1Id).HasColumnName("stan1_id");
            entity.Property(e => e.Stan2Id).HasColumnName("stan2_id");
            entity.Property(e => e.TrackName).HasColumnName("track_name");
        });

        modelBuilder.Entity<Urran>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("urran");

            entity.Property(e => e.Anker)
                .HasMaxLength(50)
                .HasColumnName("anker");
            entity.Property(e => e.Avgrepairtime3fact)
                .HasMaxLength(50)
                .HasColumnName("avgrepairtime3fact");
            entity.Property(e => e.Avgrepairtime3norm)
                .HasMaxLength(50)
                .HasColumnName("avgrepairtime3norm");
            entity.Property(e => e.Ballastbbigi)
                .HasMaxLength(50)
                .HasColumnName("ballastbbigi");
            entity.Property(e => e.Ballastbsmalli).HasColumnName("ballastbsmalli");
            entity.Property(e => e.Ballastfact).HasColumnName("ballastfact");
            entity.Property(e => e.Ballastk)
                .HasMaxLength(50)
                .HasColumnName("ballastk");
            entity.Property(e => e.Ballastnorm).HasColumnName("ballastnorm");
            entity.Property(e => e.Classgroupcategory)
                .HasMaxLength(50)
                .HasColumnName("classgroupcategory");
            entity.Property(e => e.Countotstup).HasColumnName("countotstup");
            entity.Property(e => e.Defectbbigi).HasColumnName("defectbbigi");
            entity.Property(e => e.Defectbsmalli).HasColumnName("defectbsmalli");
            entity.Property(e => e.Defectfact).HasColumnName("defectfact");
            entity.Property(e => e.Defectk)
                .HasMaxLength(50)
                .HasColumnName("defectk");
            entity.Property(e => e.Defectnorm).HasColumnName("defectnorm");
            entity.Property(e => e.Gruzonapryazhennost)
                .HasMaxLength(50)
                .HasColumnName("gruzonapryazhennost");
            entity.Property(e => e.Idstation1).HasColumnName("idstation1");
            entity.Property(e => e.Idstation2).HasColumnName("idstation2");
            entity.Property(e => e.Intensivnots3katFact)
                .HasMaxLength(50)
                .HasColumnName("intensivnots3kat_fact");
            entity.Property(e => e.Intensivnots3katNorm)
                .HasMaxLength(50)
                .HasColumnName("intensivnots3kat_norm");
            entity.Property(e => e.Kmk).HasColumnName("kmk");
            entity.Property(e => e.Kmn).HasColumnName("kmn");
            entity.Property(e => e.Koefrashod)
                .HasMaxLength(50)
                .HasColumnName("koefrashod");
            entity.Property(e => e.Koefrashodkr)
                .HasMaxLength(50)
                .HasColumnName("koefrashodkr");
            entity.Property(e => e.Koefrashodkrs)
                .HasMaxLength(50)
                .HasColumnName("koefrashodkrs");
            entity.Property(e => e.Koeftehsost)
                .HasMaxLength(50)
                .HasColumnName("koeftehsost");
            entity.Property(e => e.Lambdaopasn3fact)
                .HasMaxLength(50)
                .HasColumnName("lambdaopasn3fact");
            entity.Property(e => e.Lambdaopasn3norm)
                .HasMaxLength(50)
                .HasColumnName("lambdaopasn3norm");
            entity.Property(e => e.LastKrYear).HasColumnName("last_kr_year");
            entity.Property(e => e.LastRepairType)
                .HasMaxLength(50)
                .HasColumnName("last_repair_type");
            entity.Property(e => e.LastRepairYear)
                .HasMaxLength(50)
                .HasColumnName("last_repair_year");
            entity.Property(e => e.Length).HasMaxLength(50);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.NormativetonnageKr)
                .HasMaxLength(50)
                .HasColumnName("normativetonnage_kr");
            entity.Property(e => e.NormativetonnageSr)
                .HasMaxLength(50)
                .HasColumnName("normativetonnage_sr");
            entity.Property(e => e.NormativeyearsKr).HasColumnName("normativeyears_kr");
            entity.Property(e => e.NormativeyearsSr)
                .HasMaxLength(50)
                .HasColumnName("normativeyears_sr");
            entity.Property(e => e.Ostatresurs)
                .HasMaxLength(50)
                .HasColumnName("ostatresurs");
            entity.Property(e => e.Ostatresursyear).HasColumnName("ostatresursyear");
            entity.Property(e => e.OtsCount).HasColumnName("ots_count");
            entity.Property(e => e.OtsHours).HasColumnName("ots_hours");
            entity.Property(e => e.Pch)
                .HasMaxLength(50)
                .HasColumnName("pch");
            entity.Property(e => e.PercentServiceLife)
                .HasMaxLength(50)
                .HasColumnName("percent_service_life");
            entity.Property(e => e.Pkk).HasColumnName("pkk");
            entity.Property(e => e.Pkn).HasColumnName("pkn");
            entity.Property(e => e.Predotkazindex)
                .HasMaxLength(50)
                .HasColumnName("predotkazindex");
            entity.Property(e => e.Progyear).HasColumnName("progyear");
            entity.Property(e => e.Proptonnage)
                .HasMaxLength(50)
                .HasColumnName("proptonnage");
            entity.Property(e => e.Railtype)
                .HasMaxLength(50)
                .HasColumnName("railtype");
            entity.Property(e => e.Razdsloy)
                .HasMaxLength(50)
                .HasColumnName("razdsloy");
            entity.Property(e => e.Readykoef3fact)
                .HasMaxLength(50)
                .HasColumnName("readykoef3fact");
            entity.Property(e => e.Readykoef3norm)
                .HasMaxLength(50)
                .HasColumnName("readykoef3norm");
            entity.Property(e => e.Remresurs)
                .HasMaxLength(50)
                .HasColumnName("remresurs");
            entity.Property(e => e.Remresursyear).HasColumnName("remresursyear");
            entity.Property(e => e.Rodbalasta)
                .HasMaxLength(50)
                .HasColumnName("rodbalasta");
            entity.Property(e => e.Servicelife).HasColumnName("servicelife");
            entity.Property(e => e.Skrepbbigi)
                .HasMaxLength(50)
                .HasColumnName("skrepbbigi");
            entity.Property(e => e.Skrepbsmalli)
                .HasMaxLength(50)
                .HasColumnName("skrepbsmalli");
            entity.Property(e => e.Skrepfact)
                .HasMaxLength(50)
                .HasColumnName("skrepfact");
            entity.Property(e => e.Skrepk)
                .HasMaxLength(50)
                .HasColumnName("skrepk");
            entity.Property(e => e.Skrepnorm)
                .HasMaxLength(50)
                .HasColumnName("skrepnorm");
            entity.Property(e => e.Sleeperstype)
                .HasMaxLength(50)
                .HasColumnName("sleeperstype");
            entity.Property(e => e.Speedfreight).HasColumnName("speedfreight");
            entity.Property(e => e.Speedpass).HasColumnName("speedpass");
            entity.Property(e => e.Tonngefact)
                .HasMaxLength(50)
                .HasColumnName("tonngefact");
            entity.Property(e => e.Track).HasColumnName("track");
            entity.Property(e => e.Vidremont)
                .HasMaxLength(50)
                .HasColumnName("vidremont");
            entity.Property(e => e.Vihodbbigi)
                .HasMaxLength(50)
                .HasColumnName("vihodbbigi");
            entity.Property(e => e.Vihodbsmalli)
                .HasMaxLength(50)
                .HasColumnName("vihodbsmalli");
            entity.Property(e => e.Vihodfact).HasColumnName("vihodfact");
            entity.Property(e => e.Vihodk)
                .HasMaxLength(50)
                .HasColumnName("vihodk");
            entity.Property(e => e.Vihodnorm).HasColumnName("vihodnorm");
            entity.Property(e => e.Vspleskbbigi)
                .HasMaxLength(50)
                .HasColumnName("vspleskbbigi");
            entity.Property(e => e.Vspleskbsmalli)
                .HasMaxLength(50)
                .HasColumnName("vspleskbsmalli");
            entity.Property(e => e.Vspleskfact)
                .HasMaxLength(50)
                .HasColumnName("vspleskfact");
            entity.Property(e => e.Vspleskk)
                .HasMaxLength(50)
                .HasColumnName("vspleskk");
            entity.Property(e => e.Vsplesknorm)
                .HasMaxLength(50)
                .HasColumnName("vsplesknorm");
            entity.Property(e => e.Woodbbigi)
                .HasMaxLength(50)
                .HasColumnName("woodbbigi");
            entity.Property(e => e.Woodbsmalli).HasColumnName("woodbsmalli");
            entity.Property(e => e.Woodfact).HasColumnName("woodfact");
            entity.Property(e => e.Woodk)
                .HasMaxLength(50)
                .HasColumnName("woodk");
            entity.Property(e => e.Woodnorm).HasColumnName("woodnorm");
            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.Yearprognoz).HasColumnName("yearprognoz");
            entity.Property(e => e.Zatratinas)
                .HasMaxLength(50)
                .HasColumnName("zatratinas");

            entity.HasOne(d => d.Idstation1Navigation).WithMany()
                .HasForeignKey(d => d.Idstation1)
                .HasConstraintName("urran_fk");

            entity.HasOne(d => d.Idstation2Navigation).WithMany()
                .HasForeignKey(d => d.Idstation2)
                .HasConstraintName("urran_fk_1");
        });

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

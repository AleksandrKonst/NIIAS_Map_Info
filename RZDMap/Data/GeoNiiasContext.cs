using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RZDMapRailwaysApi.Models;

namespace RZDMapRailwaysApi.Data;

public partial class GeoNiiasContext : IdentityDbContext<IdentityUser>
{
    public GeoNiiasContext(DbContextOptions<GeoNiiasContext> options) : base(options)
    {
    }

    public virtual DbSet<Station> Stations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.Esr).HasName("stations_pkey");

            entity.ToTable("stations");

            entity.Property(e => e.Esr)
                .ValueGeneratedNever()
                .HasColumnName("esr");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.OsmId).HasColumnName("osm_id");
            entity.Property(e => e.User).HasColumnName("user");
        });

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

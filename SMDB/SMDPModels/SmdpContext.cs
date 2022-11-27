using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SMDB.SMDPModels;

public partial class SmdpContext : DbContext
{
    public SmdpContext()
    {
    }

    public SmdpContext(DbContextOptions<SmdpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DailyPrice> DailyPrices { get; set; }

    public virtual DbSet<Fund> Funds { get; set; }

    public virtual DbSet<Industry> Industries { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<LetterType> LetterTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=192.168.110.120;user id=sa;password=111@a;initial catalog=SMDP;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Persian_100_CI_AI");

        modelBuilder.Entity<DailyPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Companie__3214EC070F429F2A");
        });

        modelBuilder.Entity<Fund>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Indices__40BC8AA10C8C24C8");

            entity.Property(e => e.InstituteType).UseCollation("Persian_100_BIN");
        });

        modelBuilder.Entity<Industry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Industri__3214EC074F81A4CF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IndustryName).UseCollation("Persian_100_BIN");
            entity.Property(e => e.IndustryNameEnglish).UseCollation("Persian_100_BIN");
        });
        modelBuilder.HasSequence("hibernate_sequence");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

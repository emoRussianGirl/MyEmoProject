using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyEmoProject.Models;

namespace MyEmoProject;

public partial class PersonsDbContext : DbContext
{
    public PersonsDbContext()
    {
    }

    public PersonsDbContext(DbContextOptions<PersonsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DopInfo> DopInfos { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ngknn.ru;User ID=21p;Password=12357;Initial Catalog=PersonsDb;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DopInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("DopInfo_pk");

            entity.ToTable("DopInfo");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Gender_pk");

            entity.ToTable("Gender");

            entity.Property(e => e.GenderName).HasMaxLength(50);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Person_pk");

            entity.ToTable("Person");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasMany(d => d.DopInfos).WithMany(p => p.People)
                .UsingEntity<Dictionary<string, object>>(
                    "PersonDopInfo",
                    r => r.HasOne<DopInfo>().WithMany()
                        .HasForeignKey("DopInfoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("PersonDopInfo_DopInfo_Id_fk"),
                    l => l.HasOne<Person>().WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("PersonDopInfo_Person_Id_fk"),
                    j =>
                    {
                        j.HasKey("PersonId", "DopInfoId").HasName("PersonDopInfo_pk");
                        j.ToTable("PersonDopInfo");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

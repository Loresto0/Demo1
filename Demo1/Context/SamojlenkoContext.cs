using System;
using System.Collections.Generic;
using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Context;

public partial class SamojlenkoContext : DbContext
{
    public SamojlenkoContext()
    {
    }

    public SamojlenkoContext(DbContextOptions<SamojlenkoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=45.67.56.214; Port=5454; DataBase=samojlenko; Username=samojlenko; Password=40exq5RZ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Idclient).HasName("client_pk");

            entity.ToTable("client", "Demo1");

            entity.Property(e => e.Idclient).HasColumnName("idclient");
            entity.Property(e => e.Idgender).HasColumnName("idgender");
            entity.Property(e => e.Nameclient).HasColumnName("nameclient");

            entity.HasOne(d => d.IdgenderNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Idgender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_gender_fk");

            entity.HasMany(d => d.Idtags).WithMany(p => p.Idclients)
                .UsingEntity<Dictionary<string, object>>(
                    "Tagofclient",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("Idtag")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tagofclient_tag_fk"),
                    l => l.HasOne<Client>().WithMany()
                        .HasForeignKey("Idclient")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tagofclient_client_fk"),
                    j =>
                    {
                        j.HasKey("Idclient", "Idtag").HasName("tagofclient_pk");
                        j.ToTable("tagofclient", "Demo1");
                        j.IndexerProperty<int>("Idclient").HasColumnName("idclient");
                        j.IndexerProperty<int>("Idtag").HasColumnName("idtag");
                    });
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Idgender).HasName("gender_pk");

            entity.ToTable("gender", "Demo1");

            entity.Property(e => e.Idgender).HasColumnName("idgender");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Idmanufacturer).HasName("manufacturer_pk");

            entity.ToTable("manufacturer", "Demo1");

            entity.Property(e => e.Idmanufacturer).HasColumnName("idmanufacturer");
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Idproduct).HasName("product_pk");

            entity.ToTable("product", "Demo1");

            entity.Property(e => e.Idproduct).HasColumnName("idproduct");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Mainimagepath).HasColumnName("mainimagepath");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Idtag).HasName("tag_pk");

            entity.ToTable("tag", "Demo1");

            entity.Property(e => e.Idtag).HasColumnName("idtag");
            entity.Property(e => e.Color).HasColumnName("color");
            entity.Property(e => e.Titletag).HasColumnName("titletag");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

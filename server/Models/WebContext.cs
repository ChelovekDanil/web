using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DBClasses;

public partial class WebContext : DbContext
{
    public WebContext()
    {
    }

    public WebContext(DbContextOptions<WebContext> options) : base(options)
    {
    }

    public virtual DbSet<Image> Images { get; set; }
    public virtual DbSet<Popular> Populars { get; set; }
    public virtual DbSet<Serials> Serials { get; set; }
    public virtual DbSet<Films> Films { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=web;Username=postgres;Password=But64aga@da");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Image>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("images");

            entity.Property(e => e.Discriptions)
                .HasMaxLength(50)
                .HasColumnName("discriptions");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(32)
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasMaxLength(1000)
                .HasColumnName("url");
        });


        modelBuilder.Entity<Popular>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("popular");

            entity.Property(e => e.Discriptions)
                .HasMaxLength(40)
                .HasColumnName("discription");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(32)
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Serials>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("serials");

            entity.Property(e => e.Discriptions)
                .HasMaxLength(40)
                .HasColumnName("discription");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(32)
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Films>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("films");

            entity.Property(e => e.Discriptions)
                .HasMaxLength(40)
                .HasColumnName("discription");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(32)
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("url");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

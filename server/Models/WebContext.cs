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

    public virtual DbSet<Movies> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=web;Username=postgres;Password=But64aga@da");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Movies>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("movie");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(32)
                .HasColumnName("title");
            entity.Property(e => e.Discription)
                .HasMaxLength(40)
                .HasColumnName("discription");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
            entity.Property(e => e.Category)
                .HasMaxLength(6)
                .HasColumnName("category");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Models;

namespace NetflixWebApi;

public partial class WebContext : DbContext
{
    public WebContext()
    {
    }

    public WebContext(DbContextOptions<WebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MovieTodo> Movies { get; set; }
    public virtual DbSet<UsersTodo> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=your;Database=your;Username=your;Password=your");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieTodo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("movie");

            entity.Property(e => e.Category)
                .HasMaxLength(6)
                .HasColumnName("category");
            entity.Property(e => e.Discription)
                .HasMaxLength(40)
                .HasColumnName("discription");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(32)
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
        });

        modelBuilder.Entity<UsersTodo>(entity =>
        {
            entity
                .ToTable("users")
                .HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(300)
                .HasColumnName("refreshtoken");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace INVEOS.Models;

public partial class InveosDbContext : DbContext
{
    public InveosDbContext()
    {
    }

    public InveosDbContext(DbContextOptions<InveosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GUser> GUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("server=localhost; database=InveosDB; integrated security=true; Trust Server Certificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_USERg");

            entity.ToTable("gUser");

            entity.HasIndex(e => e.Username, "UQ__User__F3DBC57276C4C14E").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_USER");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__F3DBC57285AB349E").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

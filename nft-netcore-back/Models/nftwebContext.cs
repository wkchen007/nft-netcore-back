using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace nft_netcore_back.Models;

public partial class nftwebContext : DbContext
{
    public nftwebContext(DbContextOptions<nftwebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<nft> nft { get; set; }

    public virtual DbSet<users> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<nft>(entity =>
        {
            entity.Property(e => e.description).HasColumnType("text");
            entity.Property(e => e.image)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.meta)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.userId).HasDefaultValue(0);
        });

        modelBuilder.Entity<users>(entity =>
        {
            entity.HasKey(e => e.email);

            entity.Property(e => e.email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.first_name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.id).ValueGeneratedOnAdd();
            entity.Property(e => e.last_name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.wallet_address)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

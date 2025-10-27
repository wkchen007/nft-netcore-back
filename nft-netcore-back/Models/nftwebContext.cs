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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

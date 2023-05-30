using System;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Models
{
public class FurnitureDbContext : DbContext
{
    public FurnitureDbContext(DbContextOptions<FurnitureDbContext> options) : base(options) { }
    public DbSet<Furniture>? Furnitures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Furniture>(entity =>
            {
                entity.Property(f => f.Product)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(f => f.Description)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(f => f.Material)
                      .HasMaxLength(50);

                entity.Property(f => f.Dimensions)
                      .HasMaxLength(50);

                entity.Property(f => f.Price)
                      .HasColumnType("decimal(18, 2)")
                      .IsRequired();
            });
        }
}
}
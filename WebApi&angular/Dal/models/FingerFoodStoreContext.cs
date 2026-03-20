using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.models;

public partial class FingerFoodStoreContext : DbContext
{
    public FingerFoodStoreContext()
    {
    }

    public FingerFoodStoreContext(DbContextOptions<FingerFoodStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Shopping> Shoppings { get; set; }

    public virtual DbSet<ShoppingDetail> ShoppingDetails { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-I97K2IC;Database=fingerFoodStore;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Hebrew_100_CI_AS");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryCode);

            entity.ToTable("Category");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerCode);

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductCode);

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Size)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.CategoryCodeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fK_Products_Category");
        });

        modelBuilder.Entity<Shopping>(entity =>
        {
            entity.HasKey(e => e.ShoppingCode);

            entity.ToTable("Shopping");

            entity.Property(e => e.Remark)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CustomerCodeNavigation).WithMany(p => p.Shoppings)
                .HasForeignKey(d => d.CustomerCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shopping_Customers");
        });

        modelBuilder.Entity<ShoppingDetail>(entity =>
        {
            entity.HasKey(e => e.ShoppingDetailsCode);

            entity.HasOne(d => d.ProductCodeNavigation).WithMany(p => p.ShoppingDetails)
                .HasForeignKey(d => d.ProductCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fK_ShoppingDetails_Products");

            entity.HasOne(d => d.ShoppingCodeNavigation).WithMany(p => p.ShoppingDetails)
                .HasForeignKey(d => d.ShoppingCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fK_ShoppingDetails_Shopping");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__Tables__7D5F01EEEED3EA7D");

            entity.Property(e => e.IsOccupied).HasDefaultValue(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

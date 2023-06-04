using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Product_Catalog.Entity;

public partial class CatalogContext : DbContext
{
    public CatalogContext()
    {
    }

    public CatalogContext(DbContextOptions<CatalogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = DESKTOP-7OO5JHF; Database = Catalog; Trusted_Connection=True; Trustservercertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryNo).HasName("PK__Category__D54E026359B10436");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryNo)
                .ValueGeneratedNever()
                .HasColumnName("category_No");
            entity.Property(e => e.CategoryName)
                .IsUnicode(false)
                .HasColumnName("category_Name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductNo).HasName("PK__Product__47029D624602C49E");

            entity.ToTable("Product");

            entity.Property(e => e.ProductNo)
                .ValueGeneratedNever()
                .HasColumnName("product_No");
            entity.Property(e => e.Brand).IsUnicode(false);
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Specification)
                .IsUnicode(false)
                .HasColumnName("specification");
            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategory_Id");

            //entity.HasOne(d => d.SubCategory).WithMany(p => p.Products)
            //    .HasForeignKey(d => d.SubCategoryId)
            //    .HasConstraintName("FK__Product__SubCate__5DCAEF64");
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.SubCategoryNo).HasName("PK__SubCateg__830F9A97EDF43211");

            entity.ToTable("SubCategory");

            entity.Property(e => e.SubCategoryNo)
                .ValueGeneratedNever()
                .HasColumnName("SubCategory_No");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.SubCategoryName)
                .IsUnicode(false)
                .HasColumnName("SubCategory_Name");

            //entity.HasOne(d => d.Category).WithMany(p => p.SubCategories)
            //    .HasForeignKey(d => d.CategoryId)
            //    .HasConstraintName("FK__SubCatego__categ__5AEE82B9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

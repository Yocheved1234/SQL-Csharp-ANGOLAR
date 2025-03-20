using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal_Repository.Modules;

public partial class ChineseAuction1Context : DbContext
{
    public ChineseAuction1Context()
    {
    }

    public ChineseAuction1Context(DbContextOptions<ChineseAuction1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Buy> Buys { get; set; }

    public virtual DbSet<BuysDetail> BuysDetails { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-323VMQ4;Initial Catalog=ChineseAuction1; Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Buys__3214EC07BD7C353B");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Note).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.BuysNavigation)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_User");
        });

        modelBuilder.Entity<BuysDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BuysDeta__3214EC07FD4AAD6E");

            entity.HasOne(d => d.Buy).WithMany(p => p.BuysDetails)
                .HasForeignKey(d => d.BuyId)
                .HasConstraintName("FK_Buy");

            entity.HasOne(d => d.Product).WithMany(p => p.BuysDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Product");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07EF52CDA6");

            entity.Property(e => e.NameCategory).HasMaxLength(20);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07B2BD6CE6");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.DescriptionP).HasMaxLength(100);
            entity.Property(e => e.ImageP).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Category");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07ED4B344D");

            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.NameU).HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

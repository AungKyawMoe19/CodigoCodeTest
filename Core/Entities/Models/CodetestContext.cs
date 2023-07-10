using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities.Models;

public partial class CodetestContext : DbContext
{
    public CodetestContext()
    {
    }

    public CodetestContext(DbContextOptions<CodetestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Buyevoucher> Buyevouchers { get; set; }

    public virtual DbSet<Evoucher> Evouchers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure your database connection here
        // optionsBuilder.UseMySql("server=localhost;database=codigo;uid=root;pwd=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_0900_ai_ci").HasCharSet("utf8mb4");

        modelBuilder.Entity<Buyevoucher>(entity =>
        {
            entity.HasKey(e => e.BuyTypeId).HasName("PRIMARY");

            entity.ToTable("buyevoucher");

            entity.HasIndex(e => e.EVoucherId, "eVoucherId_idx");

            entity.Property(e => e.BuyTypeId).HasMaxLength(50).HasColumnName("buyTypeId");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.BuyType).HasMaxLength(50).HasColumnName("buyType");
            entity.Property(e => e.CreatedBy).HasMaxLength(50).HasColumnName("createdBy");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime").HasColumnName("createdOn");
            entity.Property(e => e.EVoucherId).HasMaxLength(50).HasColumnName("eVoucherId");
            entity.Property(e => e.ModifyBy).HasMaxLength(50).HasColumnName("modifyBy");
            entity.Property(e => e.ModifyOn).HasColumnType("datetime").HasColumnName("modifyOn");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.Phone).HasMaxLength(15).HasColumnName("phone");

            entity.HasOne(d => d.EVoucher)
                     .WithMany(p => p.Buyevouchers)
                     .HasForeignKey(d => d.EVoucherId)
                     .HasConstraintName("eVoucherId_FK");
        });

        modelBuilder.Entity<Evoucher>(entity =>
        {
            entity.HasKey(e => e.EVoucherId).HasName("PRIMARY");
            entity.ToTable("evoucher");

            entity.Property(e => e.EVoucherId).HasMaxLength(50).HasColumnName("eVoucherId");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Amount).HasPrecision(2).HasColumnName("amount");
            entity.Property(e => e.CreatedBy).HasMaxLength(50).HasColumnName("createdBy");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime").HasColumnName("createdOn");
            entity.Property(e => e.Description).HasMaxLength(200).HasColumnName("description");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime").HasColumnName("expiryDate");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.MaxEvoucher).HasColumnName("maxEVoucher");
            entity.Property(e => e.MaxGiftEvoucher).HasColumnName("maxGiftEVoucher");
            entity.Property(e => e.ModifyBy).HasMaxLength(50).HasColumnName("modifyBy");
            entity.Property(e => e.ModifyOn).HasColumnType("datetime").HasColumnName("modifyOn");
            entity.Property(e => e.QrCode).HasMaxLength(50).HasColumnName("qrCode");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Title).HasMaxLength(200).HasColumnName("title");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");
            entity.ToTable("order");

            entity.HasIndex(e => e.EVoucherId, "eVoucherId_idx");
            entity.HasIndex(e => e.PaymentId, "paymentId_idx");
            entity.HasIndex(e => e.TransactionId, "transactionId_FK_idx");

            entity.Property(e => e.OrderId).HasMaxLength(50).HasColumnName("orderId");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.EVoucherId).HasMaxLength(50).HasColumnName("eVoucherId");
            entity.Property(e => e.OrderCode).HasMaxLength(50).HasColumnName("orderCode");
            entity.Property(e => e.OrderDate).HasColumnType("datetime").HasColumnName("orderDate");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime").HasColumnName("paymentDate");
            entity.Property(e => e.PaymentId).HasMaxLength(50).HasColumnName("paymentId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TransactionId).HasMaxLength(50).HasColumnName("transactionId");

            entity.HasOne(d => d.EVoucher)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.EVoucherId)
                .HasConstraintName("eVouherId_FK");

            entity.HasOne(d => d.Payment)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("paymentTypeId_FK");

            entity.HasOne(d => d.Transaction)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("transactionId_FK");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PRIMARY");
            entity.ToTable("payment");

            entity.Property(e => e.PaymentId).HasMaxLength(50).HasColumnName("paymentId");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedBy).HasMaxLength(50).HasColumnName("createdBy");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime").HasColumnName("createdOn");
            entity.Property(e => e.ModifyBy).HasMaxLength(50).HasColumnName("modifyBy");
            entity.Property(e => e.ModifyOn).HasColumnType("datetime").HasColumnName("modifyOn");
            entity.Property(e => e.PaymentType).HasMaxLength(45).HasColumnName("paymentType");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PRIMARY");

            entity.ToTable("promotion");

            entity.HasIndex(e => e.EVoucherId, "eVoucherId_idx");

            entity.Property(e => e.PromotionId)
                .HasMaxLength(50)
                .HasColumnName("promotionId");

            entity.Property(e => e.Active).HasColumnName("active");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("createdBy");

            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("createdOn");

            entity.Property(e => e.EVoucherId)
                .HasMaxLength(50)
                .HasColumnName("eVoucherId");

            entity.Property(e => e.ModifyBy)
                .HasMaxLength(50)
                .HasColumnName("modifyBy");

            entity.Property(e => e.ModifyOn)
                .HasColumnType("datetime")
                .HasColumnName("modifyOn");

            entity.Property(e => e.PromoCode)
                .HasMaxLength(11)
                .HasColumnName("promoCode");

            entity.HasOne(d => d.EVoucher).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.EVoucherId)
                .HasConstraintName("eVoucherId_ForeignKey");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("transaction");

            entity.HasIndex(e => e.EVoucherId, "eVoucherId_idx");

            entity.Property(e => e.TransactionId)
                .HasMaxLength(50)
                .HasColumnName("transactionId");

            entity.Property(e => e.Amount).HasColumnName("amount");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("createdBy");

            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("createdOn");

            entity.Property(e => e.EVoucherId)
                .HasMaxLength(50)
                .HasColumnName("eVoucherId");

            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");

            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.EVoucher).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.EVoucherId)
                .HasConstraintName("eVoucherId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

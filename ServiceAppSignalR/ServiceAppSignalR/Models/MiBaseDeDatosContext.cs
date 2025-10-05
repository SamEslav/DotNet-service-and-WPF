using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServiceAppSignalR.Models;

public partial class MiBaseDeDatosContext : DbContext
{
    public MiBaseDeDatosContext()
    {
    }

    public MiBaseDeDatosContext(DbContextOptions<MiBaseDeDatosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HubConnection> HubConnections { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Population> Populations { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MiBaseDeDatos;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HubConnection>(entity =>
        {
            entity.ToTable("HubConnection");

            entity.Property(e => e.ConnectionId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification", tb =>
                {
                    tb.HasTrigger("tr_dbo_Notification_89296f72-f85a-49b7-9900-94e9bc747dea_Sender");
                    tb.HasTrigger("tr_dbo_Notification_8f401f7c-94cb-4bae-bcb2-6d660d459f8d_Sender");
                });

            entity.Property(e => e.Message)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.MessageType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NotificationDateTime).HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Population>(entity =>
        {
            entity.ToTable("Population");

            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.ToTable("TblUser");

            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

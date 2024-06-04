using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KolganovPS.Models.PetrovDB;

public partial class PetrovDB : DbContext
{
    public PetrovDB()
    {
    }

    public PetrovDB(DbContextOptions<PetrovDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Client_Route> Client_Routes { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Sending> Sendings { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PetrovDB;Username=postgres;Password=Golf25");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Cars_pkey");

            entity.Property(e => e.Driver).ValueGeneratedOnAdd();
            entity.Property(e => e.NumberCar).HasColumnType("character varying");
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Cargo_pkey");

            entity.ToTable("Cargo");

            entity.Property(e => e.ClientID).ValueGeneratedOnAdd();
            entity.Property(e => e.Destination).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.WarehouseID).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Client).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.ClientID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cargo_ClientID_fkey");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.WarehouseID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cargo_WarehouseID_fkey");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Client_pkey");

            entity.ToTable("Client");

            entity.Property(e => e.Cargo).HasMaxLength(100);
            entity.Property(e => e.FIO).HasMaxLength(100);
        });

        modelBuilder.Entity<Client_Route>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Client_Route");

            entity.Property(e => e.Client_Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Route_Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Client).WithMany()
                .HasForeignKey(d => d.Client_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Client_Route_Client_Id_fkey");

            entity.HasOne(d => d.Route).WithMany()
                .HasForeignKey(d => d.Route_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Client_Route_Route_Id_fkey");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Drivers_pkey");

            entity.Property(e => e.CarsID).ValueGeneratedOnAdd();
            entity.Property(e => e.FIO).HasMaxLength(100);

            entity.HasOne(d => d.Cars).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.CarsID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Drivers_CarsID_fkey");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Route_pkey");

            entity.ToTable("Route");

            entity.Property(e => e.CarID).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.NumberDaysRoad).HasColumnType("character varying");
            entity.Property(e => e.Range).HasColumnType("character varying");

            entity.HasOne(d => d.Car).WithMany(p => p.Routes)
                .HasForeignKey(d => d.CarID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Route_CarID_fkey");
        });

        modelBuilder.Entity<Sending>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Sending_pkey");

            entity.ToTable("Sending");

            entity.Property(e => e.CargoID).ValueGeneratedOnAdd();
            entity.Property(e => e.From).HasColumnType("character varying");
            entity.Property(e => e.Where).HasColumnType("character varying");

            entity.HasOne(d => d.Cargo).WithMany(p => p.Sendings)
                .HasForeignKey(d => d.CargoID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Sending_CargoID_fkey");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.ID_).HasName("Warehouse_pkey");

            entity.ToTable("Warehouse");

            entity.Property(e => e.ID_).HasColumnName("ID ");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

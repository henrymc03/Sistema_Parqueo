using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmartParkingCR_Backend.Models;

public partial class DbSmartParkingContext : DbContext
{
    public DbSmartParkingContext()
    {
    }

    public DbSmartParkingContext(DbContextOptions<DbSmartParkingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ParkingLot> ParkingLots { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

    public virtual DbSet<RateType> RateTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Spot> Spots { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleType> VehicleTypes { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParkingLot>(entity =>
        {
            entity.HasKey(e => e.IdParkingLot);

            entity.ToTable("ParkingLot");

            entity.Property(e => e.IdParkingLot).HasColumnName("Id_ParkingLot");
            entity.Property(e => e.City).HasMaxLength(40);
            entity.Property(e => e.District).HasMaxLength(40);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Province).HasMaxLength(15);

            entity.HasMany(d => d.Users).WithMany(p => p.ParkingLots)
                .UsingEntity<Dictionary<string, object>>(
                    "ParkingLotOperator",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ParkingLot_Operator_User"),
                    l => l.HasOne<ParkingLot>().WithMany()
                        .HasForeignKey("ParkingLotId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ParkingLot_Operator_ParkingLot"),
                    j =>
                    {
                        j.HasKey("ParkingLotId", "UserId");
                        j.ToTable("ParkingLot_Operator");
                    });
        });

        modelBuilder.Entity<Rate>(entity =>
        {
            entity.HasKey(e => e.IdRate);

            entity.ToTable("Rate");

            entity.Property(e => e.IdRate).HasColumnName("Id_Rate");

            entity.HasOne(d => d.RateType).WithMany(p => p.Rates)
                .HasForeignKey(d => d.RateTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rate_Rate_Type");

            entity.HasOne(d => d.Type).WithMany(p => p.Rates)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rate_Vehicle_Type");
        });

        modelBuilder.Entity<RateType>(entity =>
        {
            entity.HasKey(e => e.IdRateType);

            entity.ToTable("Rate_Type");

            entity.Property(e => e.IdRateType).HasColumnName("Id_RateType");
            entity.Property(e => e.BookingTime)
                .HasMaxLength(20)
                .HasColumnName("Booking_Time");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.ToTable("Role");

            entity.Property(e => e.IdRole).HasColumnName("Id_Role");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Spot>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Spot");

            entity.Property(e => e.Id).HasColumnName("Id_Spot");
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.Type).HasMaxLength(15);
            entity.Property(e => e.Vehicle).HasDefaultValueSql("((0))");

          
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("PK_Ticket_1");

            entity.ToTable("Ticket", tb =>
                {
                 //   tb.HasTrigger("SetEndDay");
                   // tb.HasTrigger("SetEndDayUpdate");
                });

            entity.HasIndex(e => new { e.Spot, e.StarDay }, "uq_spot_starday").IsUnique();

            entity.Property(e => e.IdTicket).HasColumnName("Id_Ticket");
            entity.Property(e => e.EndDay).HasColumnType("datetime");
            entity.Property(e => e.StarDay).HasColumnType("datetime");

            entity.HasOne(d => d.RateType).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.RateType)
                .HasConstraintName("FK_Ticket_Rate_Type");

          //  entity.HasOne(d => d.Spot).WithMany(p => p.Ti)
            //    .HasForeignKey(d => d.SpotId)
              //  .HasConstraintName("FK_Ticket_Spot");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.User)
                .HasConstraintName("FK_Ticket_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("Id_User");
            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.Identification).HasMaxLength(10);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(15);
            entity.Property(e => e.TelNumber)
                .HasMaxLength(15)
                .HasColumnName("Tel_Number");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.IdVehicle);

            entity.ToTable("Vehicle");

            entity.HasIndex(e => e.LicensePlate, "UQ__Vehicle__026BC15C1839DBF3").IsUnique();

            entity.HasIndex(e => e.LicensePlate, "UQ__Vehicle__026BC15CF02FB308").IsUnique();

            entity.Property(e => e.IdVehicle).HasColumnName("Id_Vehicle");
            entity.Property(e => e.Brand).HasMaxLength(25);
            entity.Property(e => e.Color).HasMaxLength(20);
            entity.Property(e => e.LicensePlate).HasMaxLength(10);

            entity.HasOne(d => d.Type).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_Vehicle_Type");

          
        });

        modelBuilder.Entity<VehicleType>(entity =>
        {
            entity.HasKey(e => e.IdType);

            entity.ToTable("Vehicle_Type");

            entity.Property(e => e.IdType).HasColumnName("Id_Type");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

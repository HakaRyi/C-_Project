using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects;

public partial class PodBookingSystemContext : DbContext
{
    public PodBookingSystemContext()
    {
    }

    public PodBookingSystemContext(DbContextOptions<PodBookingSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingDetail> BookingDetails { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomSlot> RoomSlots { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<User> Users { get; set; }

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        var strConn = config["ConnectionString:DefaultConnection"];

        return strConn;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(GetConnectionString());

    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__5DE3A5B158F8269B");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId)
                .HasMaxLength(255)
                .HasColumnName("booking_id");
            entity.Property(e => e.BookingDate).HasColumnName("booking_date");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Booking__user_id__3E52440B");
        });

        modelBuilder.Entity<BookingDetail>(entity =>
        {
            entity.HasKey(e => e.BookingDetailId).HasName("PK__Booking___647E56732E0A8351");

            entity.ToTable("Booking_detail");

            entity.Property(e => e.BookingDetailId)
                .HasMaxLength(255)
                .HasColumnName("booking_detail_id");
            entity.Property(e => e.BookingId)
                .HasMaxLength(255)
                .HasColumnName("booking_id");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingDetails)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__Booking_d__booki__5070F446");

            entity.HasOne(d => d.Room).WithMany(p => p.BookingDetails)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking_d__room___5165187F");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__9C9FBF7FA6062F5B");

            entity.ToTable("Building");

            entity.Property(e => e.BuildingId)
                .HasMaxLength(255)
                .HasColumnName("building_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__ED1FC9EAE9517817");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId)
                .HasMaxLength(255)
                .HasColumnName("payment_id");
            entity.Property(e => e.BookingId)
                .HasMaxLength(255)
                .HasColumnName("booking_id");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__booking__412EB0B6");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.PaymentDetailId).HasName("PK__Payment___C66E6E3625132A86");

            entity.ToTable("Payment_detail");

            entity.Property(e => e.PaymentDetailId)
                .HasMaxLength(255)
                .HasColumnName("payment_detail_id");
            
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(255)
                .HasColumnName("payment_id");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(255)
                .HasColumnName("payment_status");
            entity.Property(e => e.Price).HasColumnName("price");
            
            entity.Property(e => e.RoomId)
                .HasMaxLength(255)
                .HasColumnName("room_id");
            

            entity.HasOne(d => d.Payment).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK__Payment_d__payme__5441852A");

            entity.HasOne(d => d.Room).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Payment_d__room___5535A963");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__760965CC8840E47B");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .HasMaxLength(255)
                .HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Room__19675A8A3467A98B");

            entity.ToTable("Room");

            entity.Property(e => e.RoomId)
                .HasMaxLength(255)
                .HasColumnName("room_id");
            entity.Property(e => e.Availability)
                .HasMaxLength(255)
                .HasColumnName("availability");
            entity.Property(e => e.AvailebleDate).HasColumnName("availeble_Date");
            entity.Property(e => e.BuildingId)
                .HasMaxLength(255)
                .HasColumnName("building_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.TypeId)
                .HasMaxLength(255)
                .HasColumnName("type_id");

            entity.HasOne(d => d.Building).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.BuildingId)
                .HasConstraintName("FK__Room__building_i__45F365D3");

            entity.HasOne(d => d.Type).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK__Room__type_id__46E78A0C");
        });

        modelBuilder.Entity<RoomSlot>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PK__Room_slo__DD771E5C9493352F");

            entity.ToTable("Room_slot");

            entity.Property(e => e.UId)
                .HasMaxLength(255)
                .HasColumnName("uId");
            entity.Property(e => e.BookingDate).HasColumnName("booking_date");
            entity.Property(e => e.BookingId)
                .HasMaxLength(255)
                .HasColumnName("booking_id");
            entity.Property(e => e.RoomId)
                .HasMaxLength(255)
                .HasColumnName("room_id");
            entity.Property(e => e.SlotId)
                .HasMaxLength(255)
                .HasColumnName("slot_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.RoomSlots)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__Room_slot__booki__4BAC3F29");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomSlots)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Room_slot__room___4CA06362");

            
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Room_typ__2C0005984675A915");

            entity.ToTable("Room_type");

            entity.Property(e => e.TypeId)
                .HasMaxLength(255)
                .HasColumnName("type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PK__Slot__971A01BB740C5EE1");

            entity.ToTable("Slot");

            entity.Property(e => e.SlotId)
                .HasMaxLength(255)
                .HasColumnName("slot_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UseridId).HasName("PK__User__DF1E117605F92C50");

            entity.ToTable("User");

            entity.Property(e => e.UseridId)
                .HasMaxLength(255)
                .HasColumnName("userid_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId)
                .HasMaxLength(255)
                .HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__role_id__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

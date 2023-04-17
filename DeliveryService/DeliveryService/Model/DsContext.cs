using System;
using System.Collections.Generic;
using System.Windows;
using DeliveryService.View;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Model;

public partial class DsContext : DbContext
{
    public DsContext()
    {
    }

    public DsContext(DbContextOptions<DsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<DeliveryHistory> DeliveryHistories { get; set; }

    public virtual DbSet<House> Houses { get; set; }

    public virtual DbSet<PickUpPoint> PickUpPoints { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    public virtual DbSet<Tariff> Tariffs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<ViewGetInformationDelivery> ViewGetInformationDeliveries { get; set; }

    public virtual DbSet<ViewGetWorkersInDelivery> ViewGetWorkersInDeliveries { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    public virtual DbSet<WorkerImage> WorkerImages { get; set; }

    public virtual DbSet<WorkersInPickUpPoint> WorkersInPickUpPoints { get; set; }

    public virtual DbSet<WorkersInStorage> WorkersInStorages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Server=NONSTOP; Database=DSe; Trusted_Connection=True; Encrypt=False;");
        }
        catch (Exception e)
        {
            Window window = new ErrorWindow("Не удалось подключится к базе данных. Обратитесь к администратору.");
            window.ShowDialog();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__addresse__3213E83F5C59590F");

            entity.ToTable("addresses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.HouseId).HasColumnName("house_id");
            entity.Property(e => e.Postcode).HasColumnName("postcode");
            entity.Property(e => e.StreetId).HasColumnName("street_id");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__addresses__city___440B1D61");

            entity.HasOne(d => d.Country).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__addresses__count__44FF419A");

            entity.HasOne(d => d.House).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.HouseId)
                .HasConstraintName("FK__addresses__house__45F365D3");

            entity.HasOne(d => d.Street).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.StreetId)
                .HasConstraintName("FK__addresses__stree__46E78A0C");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cities__3213E83F0BBBA800");

            entity.ToTable("cities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("title");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__countrie__3213E83F5F83C078");

            entity.ToTable("countries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("title");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__delivery__3213E83F15AB4996");

            entity.ToTable("delivery", tb => tb.HasTrigger("add_delivery_to_delivery_history"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PickPoint).HasColumnName("pick_point");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.RecipientId).HasColumnName("recipient_id");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.TariffId).HasColumnName("tariff_id");
            entity.Property(e => e.UpPoint).HasColumnName("up_point");

            entity.HasOne(d => d.PickPointNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.PickPoint)
                .HasConstraintName("FK__delivery__pick_p__5CD6CB2B");

            entity.HasOne(d => d.Recipient).WithMany(p => p.DeliveryRecipients)
                .HasForeignKey(d => d.RecipientId)
                .HasConstraintName("FK_urec");

            entity.HasOne(d => d.Sender).WithMany(p => p.DeliverySenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK_usen");

            entity.HasOne(d => d.Tariff).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.TariffId)
                .HasConstraintName("FK__delivery__tariff__49C3F6B7");
        });

        modelBuilder.Entity<DeliveryHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__delivery__3213E83F8E04C393");

            entity.ToTable("delivery_history");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("date_time");
            entity.Property(e => e.DeliveryId).HasColumnName("delivery_id");
            entity.Property(e => e.DeliveryStatus)
                .IsUnicode(false)
                .HasColumnName("delivery_status");

            entity.HasOne(d => d.Address).WithMany(p => p.DeliveryHistories)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__delivery___addre__5EBF139D");

            entity.HasOne(d => d.Delivery).WithMany(p => p.DeliveryHistories)
                .HasForeignKey(d => d.DeliveryId)
                .HasConstraintName("FK__delivery___deliv__4D94879B");
        });

        modelBuilder.Entity<House>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__houses__3213E83F8B1B511C");

            entity.ToTable("houses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("number");
        });

        modelBuilder.Entity<PickUpPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pick_up___3213E83FC2587E6A");

            entity.ToTable("pick_up_points");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");

            entity.HasOne(d => d.Address).WithMany(p => p.PickUpPoints)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__pick_up_p__addre__5BE2A6F2");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__position__3213E83FA4BBF0CA");

            entity.ToTable("positions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("title");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reviews__3213E83FD510D6EE");

            entity.ToTable("reviews", tb => tb.HasTrigger("add_review_to_history"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeliveryId).HasColumnName("delivery_id");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.ReviewDescription)
                .HasColumnType("text")
                .HasColumnName("review_description");

            entity.HasOne(d => d.Delivery).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.DeliveryId)
                .HasConstraintName("FK__reviews__deliver__5629CD9C");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__shifts__3213E83FF8EC0DD2");

            entity.ToTable("shifts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndedShiftAt).HasColumnName("ended_shift_at");
            entity.Property(e => e.StartedShiftAt).HasColumnName("started_shift_at");
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__storages__3213E83FCCA17553");

            entity.ToTable("storages");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.Title)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Address).WithMany(p => p.Storages)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__storages__addres__59063A47");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__streets__3213E83FA356385C");

            entity.ToTable("streets");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("title");
        });

        modelBuilder.Entity<Tariff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tariffs__3213E83F07F6CE22");

            entity.ToTable("tariffs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F7AD5AAB4");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.Firstname)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.PassportAddress).HasColumnName("passport_address");
            entity.Property(e => e.PassportNumber).HasColumnName("passport_number");
            entity.Property(e => e.PassportSeries).HasColumnName("passport_series");
            entity.Property(e => e.Patronymic)
                .IsUnicode(false)
                .HasColumnName("patronymic");
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("telephone_number");

            entity.HasOne(d => d.Address).WithMany(p => p.UserAddresses)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__users__address_i__4E88ABD4");

            entity.HasOne(d => d.PassportAddressNavigation).WithMany(p => p.UserPassportAddressNavigations)
                .HasForeignKey(d => d.PassportAddress)
                .HasConstraintName("FK__users__passport___4F7CD00D");
        });

        modelBuilder.Entity<ViewGetInformationDelivery>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_get_information_delivery");

            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("date_time");
            entity.Property(e => e.DeliveryNumber).HasColumnName("delivery_number");
            entity.Property(e => e.House)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("house");
            entity.Property(e => e.RecipientFirstname)
                .IsUnicode(false)
                .HasColumnName("recipient_firstname");
            entity.Property(e => e.RecipientLastname)
                .IsUnicode(false)
                .HasColumnName("recipient_lastname");
            entity.Property(e => e.RecipientPatronymic)
                .IsUnicode(false)
                .HasColumnName("recipient_patronymic");
            entity.Property(e => e.SenderFirstname)
                .IsUnicode(false)
                .HasColumnName("sender_firstname");
            entity.Property(e => e.SenderLastname)
                .IsUnicode(false)
                .HasColumnName("sender_lastname");
            entity.Property(e => e.SenderPatronymic)
                .IsUnicode(false)
                .HasColumnName("sender_patronymic");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("street");
        });

        modelBuilder.Entity<ViewGetWorkersInDelivery>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_get_workers_in_delivery");

            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("date_time");
            entity.Property(e => e.DeliveryNumber).HasColumnName("delivery_number");
            entity.Property(e => e.DeliveryStatus)
                .IsUnicode(false)
                .HasColumnName("delivery_status");
            entity.Property(e => e.Firstname)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.House)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("house");
            entity.Property(e => e.Lastname)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Patronymic)
                .IsUnicode(false)
                .HasColumnName("patronymic");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("street");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__workers__3213E83F39F41B30");

            entity.ToTable("workers");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PositionId).HasColumnName("position_id");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Worker)
                .HasForeignKey<Worker>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_wuz");

            entity.HasOne(d => d.Image).WithMany(p => p.Workers)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK__workers__image_i__1B9317B3");

            entity.HasOne(d => d.Position).WithMany(p => p.Workers)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__workers__positio__52593CB8");

            entity.HasMany(d => d.DeliveryHistories).WithMany(p => p.Workers)
                .UsingEntity<Dictionary<string, object>>(
                    "WorkersInDelivery",
                    r => r.HasOne<DeliveryHistory>().WithMany()
                        .HasForeignKey("DeliveryHistoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_worker_in_delivery_delivery_history"),
                    l => l.HasOne<Worker>().WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__worker_in__worke__5165187F"),
                    j =>
                    {
                        j.HasKey("WorkerId", "DeliveryHistoryId").HasName("PK__worker_i__175A4F48D5355379");
                        j.ToTable("workers_in_delivery");
                        j.IndexerProperty<int>("WorkerId").HasColumnName("worker_id");
                        j.IndexerProperty<int>("DeliveryHistoryId").HasColumnName("delivery_history_id");
                    });
        });

        modelBuilder.Entity<WorkerImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__worker_i__3213E83F635099C9");

            entity.ToTable("worker_images");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.WorkerImage1).HasColumnName("worker_image");
        });

        modelBuilder.Entity<WorkersInPickUpPoint>(entity =>
        {
            entity.HasKey(e => new { e.WorkerId, e.PickUpPointId, e.WorkingShift });

            entity.ToTable("workers_in_pick_up_points");

            entity.Property(e => e.WorkerId).HasColumnName("worker_id");
            entity.Property(e => e.PickUpPointId).HasColumnName("pick_up_point_id");
            entity.Property(e => e.WorkingShift).HasColumnName("working_shift");

            entity.HasOne(d => d.PickUpPoint).WithMany(p => p.WorkersInPickUpPoints)
                .HasForeignKey(d => d.PickUpPointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__workers_i__pick___75A278F5");

            entity.HasOne(d => d.Worker).WithMany(p => p.WorkersInPickUpPoints)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__workers_i__worke__74AE54BC");

            entity.HasOne(d => d.WorkingShiftNavigation).WithMany(p => p.WorkersInPickUpPoints)
                .HasForeignKey(d => d.WorkingShift)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__workers_i__worki__76969D2E");
        });

        modelBuilder.Entity<WorkersInStorage>(entity =>
        {
            entity.HasKey(e => new { e.WorkerId, e.StorageId, e.WorkingShift });

            entity.ToTable("workers_in_storages");

            entity.Property(e => e.WorkerId).HasColumnName("worker_id");
            entity.Property(e => e.StorageId).HasColumnName("storage_id");
            entity.Property(e => e.WorkingShift).HasColumnName("working_shift");

            entity.HasOne(d => d.Storage).WithMany(p => p.WorkersInStorages)
                .HasForeignKey(d => d.StorageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__workers_i__stora__797309D9");

            entity.HasOne(d => d.Worker).WithMany(p => p.WorkersInStorages)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__workers_i__worke__787EE5A0");

            entity.HasOne(d => d.WorkingShiftNavigation).WithMany(p => p.WorkersInStorages)
                .HasForeignKey(d => d.WorkingShift)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__workers_i__worki__7A672E12");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

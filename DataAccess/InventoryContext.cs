using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NET_Core_CRUD_API.DataAccess;

public partial class InventoryContext : DbContext
{
    public InventoryContext(DbContextOptions<InventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Product1> Products1 { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__F2D21A9694605B9D");

            entity.ToTable("City");

            entity.Property(e => e.CityId)
                .ValueGeneratedNever()
                .HasColumnName("CityID");
            entity.Property(e => e.CityName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StateId).HasColumnName("StateID");

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_Cities_States");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB85E419D3F7");

            entity.ToTable("customers");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customer_name");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1B2B161DF");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Contact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__465962298E9C2FE5");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__orders__customer__5535A963");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__product__47027DF58C4EF761");

            entity.ToTable("product", tb =>
                {
                    tb.HasTrigger("t1");
                    tb.HasTrigger("t3");
                    tb.HasTrigger("t4");
                });

            entity.HasIndex(e => e.ProductName, "product_index");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.LastUpdated).HasColumnName("last_updated");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<Product1>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED03AF28EB");

            entity.ToTable("Products");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductGenre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("product_genre");
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.ProductState)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("product_state");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__State__C3BA3B5AC312AC52");

            entity.ToTable("State");

            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.StateName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__supplier__6EE594E82AE1C36F");

            entity.ToTable("supplier", tb =>
                {
                    tb.HasTrigger("t2");
                    tb.HasTrigger("t5");
                });

            entity.HasIndex(e => new { e.SupplierName, e.PhoneNumber }, "supplier_index");

            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contact_person");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("supplier_name");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserInfoId).HasName("PK__UserInfo__5E432DF66A1CB14E");

            entity.ToTable("UserInfo");

            entity.HasIndex(e => e.UserEmail, "UQ__UserInfo__43CA316864C5E923").IsUnique();

            entity.Property(e => e.UserInfoId).HasColumnName("USER_INFO_ID");
            entity.Property(e => e.UserDob).HasColumnName("USER_DOB");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USER_EMAIL");
            entity.Property(e => e.UserFeedback)
                .HasMaxLength(300)
                .HasColumnName("USER_FEEDBACK");
            entity.Property(e => e.UserHobby)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USER_HOBBY");
            entity.Property(e => e.UserImage)
                .HasMaxLength(300)
                .HasColumnName("USER_IMAGE");
            entity.Property(e => e.UserLanguage)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USER_LANGUAGE");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USER_NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

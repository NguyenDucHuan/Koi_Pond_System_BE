using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KPOCOS.Domain.Models;

public partial class KpcosdbContext : DbContext
{
    public KpcosdbContext()
    {
    }

    public KpcosdbContext(DbContextOptions<KpcosdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<ComponentType> ComponentTypes { get; set; }

    public virtual DbSet<Decoration> Decorations { get; set; }

    public virtual DbSet<DecorationType> DecorationTypes { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<DiscountPound> DiscountPounds { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Pond> Ponds { get; set; }

    public virtual DbSet<PondComponent> PondComponents { get; set; }

    public virtual DbSet<PondDecoration> PondDecorations { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    private string? GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnection"];
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC27BD230483");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Password, "UQ__Account__87909B15E18F216A").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__Account__C9F284563D4237D8").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserName).HasMaxLength(20);

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Account__RoleID__4D94879B");
        });

        modelBuilder.Entity<Component>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Componen__3214EC270AC6D058");

            entity.ToTable("Component");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ComponentTypeId).HasColumnName("ComponentTypeID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PricePerItem).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.ComponentType).WithMany(p => p.Components)
                .HasForeignKey(d => d.ComponentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Component__Compo__5FB337D6");
        });

        modelBuilder.Entity<ComponentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Componen__3214EC2709C105A2");

            entity.ToTable("ComponentType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Decoration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Decorati__3214EC273B88C3C9");

            entity.ToTable("Decoration");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DecorationName).HasMaxLength(255);
            entity.Property(e => e.DecorationTypeId).HasColumnName("DecorationTypeID");
            entity.Property(e => e.Decription).HasMaxLength(255);
            entity.Property(e => e.PricePerSquareMeter).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.DecorationType).WithMany(p => p.Decorations)
                .HasForeignKey(d => d.DecorationTypeId)
                .HasConstraintName("FK__Decoratio__Decor__5AEE82B9");
        });

        modelBuilder.Entity<DecorationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Decorati__3214EC27982590F7");

            entity.ToTable("DecorationType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC27E7009954");

            entity.ToTable("Discount");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FieldOnDiscount).HasMaxLength(255);
            entity.Property(e => e.FinishTime).HasColumnType("datetime");
            entity.Property(e => e.MaxTotalDiscount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.MinRequireDiscount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RemainingAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<DiscountPound>(entity =>
        {
            entity.HasKey(e => new { e.DiscouId, e.AccountId }).HasName("PK__Discount__08A6B927B22D716E");

            entity.ToTable("DiscountPound");

            entity.Property(e => e.DiscouId).HasColumnName("DiscouID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Account).WithMany(p => p.DiscountPounds)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DiscountP__Accou__656C112C");

            entity.HasOne(d => d.Discou).WithMany(p => p.DiscountPounds)
                .HasForeignKey(d => d.DiscouId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DiscountP__Disco__6477ECF3");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC27A749A059");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.CreateOn).HasColumnType("datetime");
            entity.Property(e => e.DiscouId).HasColumnName("DiscouID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalMoney).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__AccountID__72C60C4A");

            entity.HasOne(d => d.Discou).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DiscouId)
                .HasConstraintName("FK__Order__DiscouID__73BA3083");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC27AD242CD7");

            entity.ToTable("OrderItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__778AC167");

            entity.HasOne(d => d.Pond).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK__OrderItem__PondI__787EE5A0");

            entity.HasOne(d => d.Service).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Servi__76969D2E");
        });

        modelBuilder.Entity<Pond>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pond__3214EC27405CA86F");

            entity.ToTable("Pond");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Area).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DesignImage)
                .HasMaxLength(1000)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.PondDepth).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PondName).HasMaxLength(255);
            entity.Property(e => e.Shape).HasMaxLength(255);

            entity.HasOne(d => d.Account).WithMany(p => p.Ponds)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pond__AccountID__68487DD7");
        });

        modelBuilder.Entity<PondComponent>(entity =>
        {
            entity.HasKey(e => new { e.ComponentId, e.PondId }).HasName("PK__PondComp__8A844FAB3F6F405D");

            entity.ToTable("PondComponent");

            entity.Property(e => e.ComponentId).HasColumnName("ComponentID");
            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Component).WithMany(p => p.PondComponents)
                .HasForeignKey(d => d.ComponentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PondCompo__Compo__6B24EA82");

            entity.HasOne(d => d.Pond).WithMany(p => p.PondComponents)
                .HasForeignKey(d => d.PondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PondCompo__PondI__6C190EBB");
        });

        modelBuilder.Entity<PondDecoration>(entity =>
        {
            entity.HasKey(e => new { e.DecorationId, e.PondId }).HasName("PK__PondDeco__13EC9D594C1A1B81");

            entity.ToTable("PondDecoration");

            entity.Property(e => e.DecorationId).HasColumnName("DecorationID");
            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.AreaAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Decoration).WithMany(p => p.PondDecorations)
                .HasForeignKey(d => d.DecorationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PondDecor__Decor__6EF57B66");

            entity.HasOne(d => d.Pond).WithMany(p => p.PondDecorations)
                .HasForeignKey(d => d.PondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PondDecor__PondI__6FE99F9F");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("PK__Rating__FCCDF85C39599C5A");

            entity.ToTable("Rating");

            entity.Property(e => e.RatingId).HasColumnName("RatingID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.CreateOn).HasColumnType("datetime");
            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Account).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rating__AccountI__7B5B524B");

            entity.HasOne(d => d.OrderItem).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.OrderItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rating__OrderIte__7C4F7684");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC27B9924792");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Service__3214EC2781386CF9");

            entity.ToTable("Service");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PricePerM2).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServiceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Service__Service__5629CD9C");
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceT__3214EC27E354EF53");

            entity.ToTable("ServiceType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.TypeName).HasMaxLength(255);
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserProf__1788CCACF7BBCD55");

            entity.ToTable("UserProfile");

            entity.HasIndex(e => e.Email, "UQ__UserProf__A9D10534D50C0DEF").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);

            entity.HasOne(d => d.Account).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserProfi__Accou__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BigBasket.Models
{
    public partial class bigbasket2406smitContext : DbContext
    {
        public bigbasket2406smitContext()
        {
        }

        public bigbasket2406smitContext(DbContextOptions<bigbasket2406smitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Object> Objects { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Upi> Upis { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountAddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AccountHolderName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AccountModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ActiveFlag).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Accounts__UserID__31B762FC");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasIndex(e => e.PhoneNumber, "UQ__Admins__85FB4E38C96C45B2")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Admins__A9D10534C06194D9")
                    .IsUnique();

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.ActiveField).HasDefaultValueSql("((1))");

                entity.Property(e => e.AdminModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AdminRegisterDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(8000);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(8000);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK__Admins__GenderID__4BAC3F29");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.ActiveField).HasDefaultValueSql("((1))");

                entity.Property(e => e.BrandAddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BrandModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.CartCreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CartModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Carts__UserID__42E1EEFE");
            });

            modelBuilder.Entity<CartDetail>(entity =>
            {
                entity.HasKey(e => e.CartDetailsId)
                    .HasName("PK__CartDeta__88F13421078FBEB7");

                entity.Property(e => e.CartDetailsId).HasColumnName("CartDetailsID");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK__CartDetai__CartI__47A6A41B");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__CartDetai__Order__498EEC8D");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__CartDetai__Produ__489AC854");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ActiveField).HasDefaultValueSql("((1))");

                entity.Property(e => e.CatAddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CatModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK__Category__Parent__0B91BA14");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityAddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CityModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CityName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Cities__CountryI__38996AB5");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CountryAddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CountryModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.ActiveField).HasDefaultValueSql("((1))");

                entity.Property(e => e.DiscountAddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiscountAmount).HasColumnType("smallmoney");

                entity.Property(e => e.DiscountEndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiscountStartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiscountsModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Discounts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Discounts__Produ__1BC821DD");
            });

            modelBuilder.Entity<Object>(entity =>
            {
                entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

                entity.Property(e => e.ObjectAddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ObjectModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ObjectValue)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Objects)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK__Objects__TypeID__286302EC");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ActiveFlag).HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderAmount).HasColumnType("money");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

                entity.Property(e => e.PayableAmount).HasColumnType("money");

                entity.Property(e => e.TotalDiscountAmount).HasColumnType("smallmoney");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.OrderOrderStatuses)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("FK__Orders__OrderSta__245D67DE");

                entity.HasOne(d => d.PaymentMethodNavigation)
                    .WithMany(p => p.OrderPaymentMethodNavigations)
                    .HasForeignKey(d => d.PaymentMethod)
                    .HasConstraintName("FK__Orders__PaymentM__2645B050");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__UserID__236943A5");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.ActiveFlag).HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderItemAddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.TotalAmount).HasColumnType("smallmoney");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderItem__Order__2B0A656D");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderItem__Produ__2BFE89A6");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentsAddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentsModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpiId).HasColumnName("UpiID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Payments__OrderI__3D2915A8");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ActiveField).HasDefaultValueSql("((1))");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductAddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductUnitOfWeightId).HasColumnName("ProductUnitOfWeightID");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Products__BrandI__123EB7A3");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__114A936A");

                entity.HasOne(d => d.ProductUnitOfWeight)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductUnitOfWeightId)
                    .HasConstraintName("FK__Products__Produc__1332DBDC");
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.HasKey(e => e.ProductDetailsId)
                    .HasName("PK__ProductD__2991D8BFFFE97B8B");

                entity.Property(e => e.ProductDetailsId).HasColumnName("ProductDetailsID");

                entity.Property(e => e.CountryOfOrigin)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductColour)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDiscription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Season)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductDe__Produ__18EBB532");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.TypeAddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TypeModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TypeValue)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Upi>(entity =>
            {
                entity.Property(e => e.UpiId).HasColumnName("UpiID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.ActiveFlag).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpiAddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpiModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Upis)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Upis__AccountID__37703C52");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.PhoneNumber, "UQ__Users__85FB4E38049388B9")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Users__A9D105347DC687A4")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ActiveFlag).HasDefaultValueSql("((1))");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(8000);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(8000);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.UserModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserRegisterDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK__Users__GenderID__2F10007B");
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__UserAddr__091C2A1BE93992A6");

                entity.ToTable("UserAddress");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressLine)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.UserAddressAddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserAddressModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__UserAddre__CityI__3D5E1FD2");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.ProfileId)
                    .HasName("PK__UserProf__290C8884A5036A45");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.ActiveField).HasDefaultValueSql("((1))");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ProfileModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProfilePic).IsUnicode(false);

                entity.Property(e => e.ProfileUpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Wallet)
                    .HasColumnType("smallmoney")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__UserProfi__Addre__440B1D61");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserProfi__UserI__4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CompanyWebManager.DataContexts;

namespace CompanyWebManager.Migrations
{
    [DbContext(typeof(ApplicationDb))]
    [Migration("20170821144633_AddTransactionDescription")]
    partial class AddTransactionDescription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompanyWebManager.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CompanyWebManager.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientEmail");

                    b.Property<int>("Country");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Street");

                    b.Property<string>("Town");

                    b.Property<int?>("Voivodeship");

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("CompanyWebManager.Models.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyEmail");

                    b.Property<int>("Country");

                    b.Property<string>("Name");

                    b.Property<int>("OwnerID");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Street");

                    b.Property<string>("Town");

                    b.Property<string>("Trade");

                    b.Property<int?>("Voivodeship");

                    b.HasKey("ID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("CompanyWebManager.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryCode");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CompanyWebManager.Models.Email", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlindCarbonCopy");

                    b.Property<string>("CarbonCopy");

                    b.Property<string>("Message");

                    b.Property<int>("OwnerID");

                    b.Property<DateTime>("ReceivedTime");

                    b.Property<string>("Receiver");

                    b.Property<bool?>("Saved");

                    b.Property<string>("Sender");

                    b.Property<string>("Subject");

                    b.Property<bool?>("Success");

                    b.Property<string>("Uid");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("CompanyWebManager.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Position");

                    b.Property<string>("PostalCode");

                    b.Property<double>("Salary");

                    b.Property<string>("Street");

                    b.Property<string>("Town");

                    b.Property<int?>("Voivodeship");

                    b.HasKey("ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CompanyWebManager.Models.Owner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("OwnerEmail");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("CompanyWebManager.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyID");

                    b.Property<string>("Description");

                    b.Property<decimal>("GrossPrice");

                    b.Property<string>("Name");

                    b.Property<decimal>("NetPrice");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CompanyWebManager.Models.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<decimal>("ProductGrossPrice");

                    b.Property<int>("ProductID");

                    b.Property<decimal>("ProductNetPrice");

                    b.Property<int>("ProductUnits");

                    b.Property<int>("TransactionID");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("CompanyWebManager.Models.Voivodeship", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Voivodeships");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CompanyWebManager.Models.Email", b =>
                {
                    b.HasOne("CompanyWebManager.Models.Owner", "Owner")
                        .WithMany("Emails")
                        .HasForeignKey("OwnerID");
                });

            modelBuilder.Entity("CompanyWebManager.Models.Owner", b =>
                {
                    b.HasOne("CompanyWebManager.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CompanyWebManager.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CompanyWebManager.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });
        }
    }
}

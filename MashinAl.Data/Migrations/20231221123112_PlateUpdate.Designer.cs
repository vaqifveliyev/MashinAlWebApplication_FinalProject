﻿// <auto-generated />
using System;
using MashinAl.Data.Persistences;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MashinAl.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231221123112_PlateUpdate")]
    partial class PlateUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MashinAl.Infastructure.Entities.BanType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("BanTypes", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BanTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Engine")
                        .HasColumnType("decimal");

                    b.Property<int>("FuelTypeId")
                        .HasColumnType("int");

                    b.Property<int>("GearboxId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBarter")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCredit")
                        .HasColumnType("bit");

                    b.Property<int>("March")
                        .HasColumnType("int");

                    b.Property<int>("MarkaId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("PublishedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("SeatsId")
                        .HasColumnType("int");

                    b.Property<int>("SellCityId")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TransmissionId")
                        .HasColumnType("int");

                    b.Property<int>("YearId")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("MarkaId");

                    b.HasIndex("ModelId");

                    b.ToTable("Cars", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.CarImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CarImages", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.CarStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("CarStatus", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.CarSupply", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("SupplyId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "SupplyId");

                    b.HasIndex("SupplyId");

                    b.ToTable("CarSupplies", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("HexCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Colors", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.GearboxType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("GearboxTypes", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Marka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Markas", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Membership.MashinAlRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", "Membership");
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Membership.MashinAlRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RolesClaims", "Membership");
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Membership.MashinAlUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", "Membership");
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Membership.MashinAlUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim", "Membership");
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Membership.MashinAlUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "Membership");
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Membership.MashinAlUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "Membership");
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Membership.MashinAlUserToken", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "Membership");
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MarkaId")
                        .HasMaxLength(200)
                        .HasColumnType("int")
                        .HasColumnName("MarkaId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("MarkaId");

                    b.ToTable("Models", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Plate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstLetter")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRejected")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("PublishedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("SecondLetter")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Plates", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ShortTitle")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Regions", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Seats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SeatTitle")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Seats", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Supply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Supply");
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.TransmissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TransmissionTypes", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Year", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("YearTitle")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Years", (string)null);
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Car", b =>
                {
                    b.HasOne("MashinAl.Infastructure.Entities.Color", null)
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MashinAl.Infastructure.Entities.Marka", null)
                        .WithMany()
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MashinAl.Infastructure.Entities.Model", null)
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.CarSupply", b =>
                {
                    b.HasOne("MashinAl.Infastructure.Entities.CarStatus", null)
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MashinAl.Infastructure.Entities.Supply", null)
                        .WithMany()
                        .HasForeignKey("SupplyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Membership.MashinAlRoleClaim", b =>
                {
                    b.HasOne("MashinAl.Infastructure.Entities.Membership.MashinAlRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Membership.MashinAlUserClaim", b =>
                {
                    b.HasOne("MashinAl.Infastructure.Entities.Membership.MashinAlUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Membership.MashinAlUserLogin", b =>
                {
                    b.HasOne("MashinAl.Infastructure.Entities.Membership.MashinAlUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Membership.MashinAlUserRole", b =>
                {
                    b.HasOne("MashinAl.Infastructure.Entities.Membership.MashinAlRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MashinAl.Infastructure.Entities.Membership.MashinAlUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Membership.MashinAlUserToken", b =>
                {
                    b.HasOne("MashinAl.Infastructure.Entities.Membership.MashinAlUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Model", b =>
                {
                    b.HasOne("MashinAl.Infastructure.Entities.Marka", null)
                        .WithMany()
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MashinAl.Infastructure.Entities.Plate", b =>
                {
                    b.HasOne("MashinAl.Infastructure.Entities.Region", null)
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using EventfulPeace.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EventfulPeace.Identity.Migrations
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20250321150144_Fixed_UserRole_Seeding")]
    partial class Fixed_UserRole_Seeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Identity")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EventfulPeace.Identity.AppRoles.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", "Identity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f3ad41d3-ee90-4988-9195-8b2a8f4f2733"),
                            ConcurrencyStamp = "1a8ba0a7-4853-42da-980d-3107784e7ab1",
                            Name = "Individual",
                            NormalizedName = "INDIVIDUAL"
                        },
                        new
                        {
                            Id = new Guid("fad1b19d-5333-4633-bd84-d67c64649f65"),
                            ConcurrencyStamp = "42174679-32f1-48b0-9524-0f00791ec760",
                            Name = "Organization",
                            NormalizedName = "ORGANIZATION"
                        },
                        new
                        {
                            Id = new Guid("fab1b19d-5333-4633-bd84-d67c64649f65"),
                            ConcurrencyStamp = "d6c9b3d1-8c3d-4a7e-8d6b-1b2c9c9c9c9c",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("EventfulPeace.Identity.AppUsers.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", "Identity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2c7667ad-716b-4606-b50d-a370ecdb1a00"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0c5bbfb2-d132-407b-9b1b-e1e640ccc14e",
                            Email = "ivanangelov414@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "IVANANGELOV414@GMAIL.COM",
                            NormalizedUserName = "NINJATABG",
                            PasswordHash = "AQAAAAIAAYagAAAAEJFCGOTxNAgjhqU5lrA63WEtv924ujxXHt0x1R70qlS8dV9Pzz4II8GOgjVOaRzuDQ==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "3A6TFN6VVZNRZEG22J777XJTPQY7342B",
                            TwoFactorEnabled = false,
                            UserName = "NinjataBG"
                        },
                        new
                        {
                            Id = new Guid("7f6e3868-ca03-44d6-b4a3-d947ac012ca6"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c77927de-61e7-4d53-be8d-a5390fafc75c",
                            Email = "ighristova5@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "IGHRISTOVA5@GMAIL.COM",
                            NormalizedUserName = "IVAYLA-G",
                            PasswordHash = "AQAAAAIAAYagAAAAEGjQ1Zes3r2XJgjoHQykiyr11OgUEDw+YDnOKeENyN7Kqi9RWKKRCtwd7ZtEyywdYA==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "NWGZ3JTQSDNS346DMU7RP4IT4BDLHIQC",
                            TwoFactorEnabled = false,
                            UserName = "Ivayla-G"
                        },
                        new
                        {
                            Id = new Guid("a9c4e2e4-f8d9-49ce-ae37-7dda2d65df90"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c5940d6f-d5c0-4f84-a262-da9b07525c3c",
                            Email = "office@yicburgas.bg",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "OFFICE@YICBURGAS.BG",
                            NormalizedUserName = "YICBURGAS",
                            PasswordHash = "AQAAAAIAAYagAAAAEEUe31maWfuZY6V8MQBzUWKerMKobDukREinVfML3Yl2z+Nr6IIQZKvX4WKqbTUw6w==",
                            PhoneNumber = "0885566781",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "FNNIT3NPOZKZK2E67WFLV5R3RGVBX7LV",
                            TwoFactorEnabled = false,
                            UserName = "YICBurgas"
                        },
                        new
                        {
                            Id = new Guid("a9c5e2e4-f8d9-49ce-ae37-7dda2d65df90"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5c94b43f-861c-4efa-a670-5627e49d354d",
                            Email = "admin123@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN123@GMAIL.COM",
                            NormalizedUserName = "ADMIN123",
                            PasswordHash = "AQAAAAIAAYagAAAAEFqtQ33BvarNRyFcmV4z48fPBlIY8zd0de90qq3Cdm1Row+2WRmEjVJk1yPadBkrSA==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "YIA26UZDSN2V2U5PVDEK4F3EJS3P5D3X",
                            TwoFactorEnabled = false,
                            UserName = "Admin123"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", "Identity");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("2c7667ad-716b-4606-b50d-a370ecdb1a00"),
                            RoleId = new Guid("f3ad41d3-ee90-4988-9195-8b2a8f4f2733")
                        },
                        new
                        {
                            UserId = new Guid("7f6e3868-ca03-44d6-b4a3-d947ac012ca6"),
                            RoleId = new Guid("f3ad41d3-ee90-4988-9195-8b2a8f4f2733")
                        },
                        new
                        {
                            UserId = new Guid("a9c4e2e4-f8d9-49ce-ae37-7dda2d65df90"),
                            RoleId = new Guid("fad1b19d-5333-4633-bd84-d67c64649f65")
                        },
                        new
                        {
                            UserId = new Guid("a9c5e2e4-f8d9-49ce-ae37-7dda2d65df90"),
                            RoleId = new Guid("fab1b19d-5333-4633-bd84-d67c64649f65")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("EventfulPeace.Identity.AppRoles.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("EventfulPeace.Identity.AppUsers.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("EventfulPeace.Identity.AppUsers.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("EventfulPeace.Identity.AppRoles.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventfulPeace.Identity.AppUsers.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("EventfulPeace.Identity.AppUsers.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

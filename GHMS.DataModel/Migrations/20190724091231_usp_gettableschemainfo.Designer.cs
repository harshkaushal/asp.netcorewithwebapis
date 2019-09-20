﻿// <auto-generated />
using System;
using GHMS.DataModel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GHMS.DataModel.Migrations
{
    [DbContext(typeof(GHMSDbContext))]
    [Migration("20190724091231_usp_gettableschemainfo")]
    partial class usp_gettableschemainfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GHMS.DataModel.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(200);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("LastUpdateUserId");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.HasKey("Id");

                    b.HasIndex("LastUpdateUserId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.AddressAudits", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AddressId");

                    b.Property<int?>("AddressId1");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(200);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("LastUpdateUserId");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedUserId");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.HasKey("Id");

                    b.HasIndex("AddressId1");

                    b.HasIndex("ModifiedUserId");

                    b.ToTable("AddressAudits");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.Common.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsPasswordChanged");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.HospitalUserContacts", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("ContactTypesId");

                    b.Property<long?>("ContactTypesId1");

                    b.Property<int>("HospitalUserDetailsId");

                    b.Property<long?>("HospitalUserDetailsId1");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("LastUpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("ContactTypesId1");

                    b.HasIndex("HospitalUserDetailsId1");

                    b.HasIndex("LastUpdateUserId");

                    b.ToTable("HospitalUserContacts");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.HospitalUserContactsAudits", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("ContactTypesId");

                    b.Property<long?>("ContactTypesId1");

                    b.Property<long>("HospitalUserContactsId");

                    b.Property<int>("HospitalUserDetailsId");

                    b.Property<long?>("HospitalUserDetailsId1");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("LastUpdateUserId");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedUserId");

                    b.HasKey("Id");

                    b.HasIndex("ContactTypesId1");

                    b.HasIndex("HospitalUserContactsId");

                    b.HasIndex("HospitalUserDetailsId1");

                    b.HasIndex("ModifiedUserId");

                    b.ToTable("HospitalUserContactsAudits");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.HospitalUserDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AspNetUserId")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("LastUpdateUserId");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AspNetUserId");

                    b.HasIndex("LastUpdateUserId");

                    b.ToTable("HospitalUserDetails");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.HospitalUserDetailsAudits", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("HospitalUserDetailsId");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("LastUpdateUserId");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedUserId");

                    b.HasKey("Id");

                    b.HasIndex("HospitalUserDetailsId");

                    b.HasIndex("ModifiedUserId");

                    b.ToTable("HospitalUserDetailsAudits");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.Hospitals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("LastUpdateUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("LastUpdateUserId");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.HospitalsAudits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("HospitalId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("LastUpdateUserId");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.HasIndex("ModifiedUserId");

                    b.ToTable("HospitalsAudits");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.LnkHospitalUserAddress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AddressId");

                    b.Property<int?>("AddressId1");

                    b.Property<int>("HospitalUserDetailsId");

                    b.Property<long?>("HospitalUserDetailsId1");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("LastUpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId1");

                    b.HasIndex("HospitalUserDetailsId1");

                    b.HasIndex("LastUpdateUserId");

                    b.ToTable("LnkHospitalUserAddress");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.LnkHospitalUserAddressAudits", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AddressId");

                    b.Property<int>("HospitalUserDetailsId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("LastUpdateUserId");

                    b.Property<long>("LnkHospitalUserAddressId");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedUserId");

                    b.HasKey("Id");

                    b.HasIndex("LnkHospitalUserAddressId");

                    b.HasIndex("ModifiedUserId");

                    b.ToTable("LnkHospitalUserAddressAudits");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.Logs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionName")
                        .HasMaxLength(128);

                    b.Property<string>("AspNetUserId")
                        .HasMaxLength(450);

                    b.Property<string>("ControllerName")
                        .HasMaxLength(128);

                    b.Property<string>("Exception");

                    b.Property<string>("Level")
                        .HasMaxLength(128);

                    b.Property<string>("LogEvent");

                    b.Property<string>("Message");

                    b.Property<string>("MessageTemplate");

                    b.Property<string>("Project")
                        .HasMaxLength(128);

                    b.Property<string>("Properties")
                        .HasColumnType("xml");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.LuContactTypes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("LastUpdateUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("LastUpdateUserId");

                    b.ToTable("LuContactTypes");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.LuContactTypesAudits", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContactTypesId");

                    b.Property<long?>("ContactTypesId1");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("LastUpdateUserId");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ContactTypesId1");

                    b.HasIndex("ModifiedUserId");

                    b.ToTable("LuContactTypesAudits");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.Address", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser", "LastUpdateUser")
                        .WithMany()
                        .HasForeignKey("LastUpdateUserId");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.AddressAudits", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId1");

                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser", "ModifiedUser")
                        .WithMany()
                        .HasForeignKey("ModifiedUserId");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.HospitalUserContacts", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.LuContactTypes", "ContactTypes")
                        .WithMany()
                        .HasForeignKey("ContactTypesId1");

                    b.HasOne("GHMS.DataModel.Models.HospitalUserDetails", "HospitalUserDetails")
                        .WithMany()
                        .HasForeignKey("HospitalUserDetailsId1");

                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser", "LastUpdateUser")
                        .WithMany()
                        .HasForeignKey("LastUpdateUserId");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.HospitalUserContactsAudits", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.LuContactTypes", "ContactTypes")
                        .WithMany()
                        .HasForeignKey("ContactTypesId1");

                    b.HasOne("GHMS.DataModel.Models.HospitalUserContacts", "HospitalUserContacts")
                        .WithMany()
                        .HasForeignKey("HospitalUserContactsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GHMS.DataModel.Models.HospitalUserDetails", "HospitalUserDetails")
                        .WithMany()
                        .HasForeignKey("HospitalUserDetailsId1");

                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser", "ModifiedUser")
                        .WithMany()
                        .HasForeignKey("ModifiedUserId");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.HospitalUserDetails", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser", "AspNetUser")
                        .WithMany()
                        .HasForeignKey("AspNetUserId");

                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser", "LastUpdateUser")
                        .WithMany()
                        .HasForeignKey("LastUpdateUserId");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.HospitalUserDetailsAudits", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.HospitalUserDetails", "HospitalUserDetails")
                        .WithMany()
                        .HasForeignKey("HospitalUserDetailsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser", "ModifiedUser")
                        .WithMany()
                        .HasForeignKey("ModifiedUserId");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.Hospitals", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser", "LastUpdateUser")
                        .WithMany()
                        .HasForeignKey("LastUpdateUserId");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.HospitalsAudits", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.Hospitals", "Hospital")
                        .WithMany()
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser", "ModifiedUser")
                        .WithMany()
                        .HasForeignKey("ModifiedUserId");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.LnkHospitalUserAddress", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId1");

                    b.HasOne("GHMS.DataModel.Models.HospitalUserDetails", "HospitalUserDetails")
                        .WithMany()
                        .HasForeignKey("HospitalUserDetailsId1");

                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser", "LastUpdateUser")
                        .WithMany()
                        .HasForeignKey("LastUpdateUserId");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.LnkHospitalUserAddressAudits", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.LnkHospitalUserAddress", "LnkHospitalUserAddress")
                        .WithMany()
                        .HasForeignKey("LnkHospitalUserAddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser", "ModifiedUser")
                        .WithMany()
                        .HasForeignKey("ModifiedUserId");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.LuContactTypes", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser", "LastUpdateUser")
                        .WithMany()
                        .HasForeignKey("LastUpdateUserId");
                });

            modelBuilder.Entity("GHMS.DataModel.Models.LuContactTypesAudits", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.LuContactTypes", "ContactTypes")
                        .WithMany()
                        .HasForeignKey("ContactTypesId1");

                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser", "ModifiedUser")
                        .WithMany()
                        .HasForeignKey("ModifiedUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GHMS.DataModel.Models.Common.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

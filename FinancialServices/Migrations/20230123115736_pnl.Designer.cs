﻿// <auto-generated />
using System;
using FinancialServices.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinancialServices.Migrations
{
    [DbContext(typeof(FinanceDbContext))]
    [Migration("20230123115736_pnl")]
    partial class pnl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FinancialServices.Data.Models.Credit", b =>
                {
                    b.Property<int>("CreditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreditId"), 1L, 1);

                    b.Property<double>("BeginValue")
                        .HasColumnType("float");

                    b.Property<int>("CreditNumber")
                        .HasColumnType("int");

                    b.Property<long>("IdEik")
                        .HasColumnType("bigint");

                    b.Property<double>("PresentValue")
                        .HasColumnType("float");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.HasKey("CreditId");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("FinancialServices.Data.Models.PNL", b =>
                {
                    b.Property<long>("idEikYear")
                        .HasColumnType("bigint");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Eik")
                        .HasColumnType("bigint");

                    b.Property<double>("N10000")
                        .HasColumnType("float");

                    b.Property<double>("N10100")
                        .HasColumnType("float");

                    b.Property<double>("N10200")
                        .HasColumnType("float");

                    b.Property<double>("N10210")
                        .HasColumnType("float");

                    b.Property<double>("N10220")
                        .HasColumnType("float");

                    b.Property<double>("N10300")
                        .HasColumnType("float");

                    b.Property<double>("N10310")
                        .HasColumnType("float");

                    b.Property<double>("N10311")
                        .HasColumnType("float");

                    b.Property<double>("N10320")
                        .HasColumnType("float");

                    b.Property<double>("N10321")
                        .HasColumnType("float");

                    b.Property<double>("N10400")
                        .HasColumnType("float");

                    b.Property<double>("N10410")
                        .HasColumnType("float");

                    b.Property<double>("N10411")
                        .HasColumnType("float");

                    b.Property<double>("N10412")
                        .HasColumnType("float");

                    b.Property<double>("N10413")
                        .HasColumnType("float");

                    b.Property<double>("N10420")
                        .HasColumnType("float");

                    b.Property<double>("N10500")
                        .HasColumnType("float");

                    b.Property<double>("N10510")
                        .HasColumnType("float");

                    b.Property<double>("N10520")
                        .HasColumnType("float");

                    b.Property<double>("N11000")
                        .HasColumnType("float");

                    b.Property<double>("N11100")
                        .HasColumnType("float");

                    b.Property<double>("N11110")
                        .HasColumnType("float");

                    b.Property<double>("N11200")
                        .HasColumnType("float");

                    b.Property<double>("N11201")
                        .HasColumnType("float");

                    b.Property<double>("N11210")
                        .HasColumnType("float");

                    b.Property<double>("N11220")
                        .HasColumnType("float");

                    b.Property<double>("N13000")
                        .HasColumnType("float");

                    b.Property<double>("N14000")
                        .HasColumnType("float");

                    b.Property<double>("N14100")
                        .HasColumnType("float");

                    b.Property<double>("N14200")
                        .HasColumnType("float");

                    b.Property<double>("N14300")
                        .HasColumnType("float");

                    b.Property<double>("N14400")
                        .HasColumnType("float");

                    b.Property<double>("N14500")
                        .HasColumnType("float");

                    b.Property<double>("N15000")
                        .HasColumnType("float");

                    b.Property<double>("N15100")
                        .HasColumnType("float");

                    b.Property<double>("N15110")
                        .HasColumnType("float");

                    b.Property<double>("N15120")
                        .HasColumnType("float");

                    b.Property<double>("N15130")
                        .HasColumnType("float");

                    b.Property<double>("N15131")
                        .HasColumnType("float");

                    b.Property<double>("N15132")
                        .HasColumnType("float");

                    b.Property<double>("N15133")
                        .HasColumnType("float");

                    b.Property<double>("N15200")
                        .HasColumnType("float");

                    b.Property<double>("N15300")
                        .HasColumnType("float");

                    b.Property<double>("N15310")
                        .HasColumnType("float");

                    b.Property<double>("N15400")
                        .HasColumnType("float");

                    b.Property<double>("N15410")
                        .HasColumnType("float");

                    b.Property<double>("N15411")
                        .HasColumnType("float");

                    b.Property<double>("N15420")
                        .HasColumnType("float");

                    b.Property<double>("N15430")
                        .HasColumnType("float");

                    b.Property<double>("N16000")
                        .HasColumnType("float");

                    b.Property<double>("N16100")
                        .HasColumnType("float");

                    b.Property<double>("N16110")
                        .HasColumnType("float");

                    b.Property<double>("N16200")
                        .HasColumnType("float");

                    b.Property<double>("N16210")
                        .HasColumnType("float");

                    b.Property<double>("N16300")
                        .HasColumnType("float");

                    b.Property<double>("N16310")
                        .HasColumnType("float");

                    b.Property<double>("N16320")
                        .HasColumnType("float");

                    b.Property<double>("N16330")
                        .HasColumnType("float");

                    b.Property<double>("N18000")
                        .HasColumnType("float");

                    b.Property<double>("N19000")
                        .HasColumnType("float");

                    b.Property<double>("N19100")
                        .HasColumnType("float");

                    b.Property<double>("N19200")
                        .HasColumnType("float");

                    b.Property<double>("N19500")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("idEikYear");

                    b.ToTable("PNLs");
                });

            modelBuilder.Entity("FinancialServices.Data.Models.ReportData", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportId"), 1L, 1);

                    b.Property<double>("AnnualTurnover")
                        .HasColumnType("float");

                    b.Property<double>("Assets")
                        .HasColumnType("float");

                    b.Property<double>("CountOfEmployees")
                        .HasColumnType("float");

                    b.Property<long>("IdEik")
                        .HasColumnType("bigint");

                    b.Property<int>("YearReport")
                        .HasColumnType("int");

                    b.HasKey("ReportId");

                    b.ToTable("ReportDatas");
                });

            modelBuilder.Entity("FinancialServices.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

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

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Theatre.Data.Models.Company", b =>
                {
                    b.Property<long>("IdEik")
                        .HasColumnType("bigint");

                    b.Property<string>("AddressActivity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KidNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Representing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeRepresenting")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEik");

                    b.HasIndex("KidNumber");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Theatre.Data.Models.Kid", b =>
                {
                    b.Property<string>("KidNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KidNumber");

                    b.ToTable("Kids");
                });

            modelBuilder.Entity("Theatre.Data.Models.MapingCompanyReport", b =>
                {
                    b.Property<long>("IdEik")
                        .HasColumnType("bigint");

                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.HasKey("IdEik", "ReportId");

                    b.HasIndex("ReportId");

                    b.ToTable("MapingCompanyReports");
                });

            modelBuilder.Entity("Theatre.Data.Models.MapingManager", b =>
                {
                    b.Property<long>("IdEik")
                        .HasColumnType("bigint");

                    b.Property<long>("IdEgn")
                        .HasColumnType("bigint");

                    b.HasKey("IdEik", "IdEgn");

                    b.HasIndex("IdEgn");

                    b.ToTable("MapingManagers");
                });

            modelBuilder.Entity("Theatre.Data.Models.MapingOwnerCompany", b =>
                {
                    b.Property<long>("IdEik")
                        .HasColumnType("bigint");

                    b.Property<long>("IdEikOwner")
                        .HasColumnType("bigint");

                    b.Property<double>("Persent")
                        .HasColumnType("float");

                    b.HasKey("IdEik", "IdEikOwner");

                    b.ToTable("MapingOwnerCompanies");
                });

            modelBuilder.Entity("Theatre.Data.Models.MapingOwnerPerson", b =>
                {
                    b.Property<long>("IdEik")
                        .HasColumnType("bigint");

                    b.Property<long>("IdEgn")
                        .HasColumnType("bigint");

                    b.Property<double>("Persent")
                        .HasColumnType("float");

                    b.HasKey("IdEik", "IdEgn");

                    b.HasIndex("IdEgn");

                    b.ToTable("MapingOwnerPersons");
                });

            modelBuilder.Entity("Theatre.Data.Models.Person", b =>
                {
                    b.Property<long>("IdEgn")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEgn");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FinancialServices.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FinancialServices.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinancialServices.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FinancialServices.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Theatre.Data.Models.Company", b =>
                {
                    b.HasOne("Theatre.Data.Models.Kid", "Kid")
                        .WithMany("Companies")
                        .HasForeignKey("KidNumber");

                    b.Navigation("Kid");
                });

            modelBuilder.Entity("Theatre.Data.Models.MapingCompanyReport", b =>
                {
                    b.HasOne("Theatre.Data.Models.Company", "Company")
                        .WithMany("MapingCompanyReports")
                        .HasForeignKey("IdEik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinancialServices.Data.Models.ReportData", "ReportData")
                        .WithMany()
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("ReportData");
                });

            modelBuilder.Entity("Theatre.Data.Models.MapingManager", b =>
                {
                    b.HasOne("Theatre.Data.Models.Person", "Person")
                        .WithMany("MapingManagers")
                        .HasForeignKey("IdEgn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theatre.Data.Models.Company", "Company")
                        .WithMany("MapingManagers")
                        .HasForeignKey("IdEik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Theatre.Data.Models.MapingOwnerCompany", b =>
                {
                    b.HasOne("Theatre.Data.Models.Company", "Company")
                        .WithMany("MapingOwnerCompanies")
                        .HasForeignKey("IdEik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Theatre.Data.Models.MapingOwnerPerson", b =>
                {
                    b.HasOne("Theatre.Data.Models.Person", "Person")
                        .WithMany("MapingOwnerPersons")
                        .HasForeignKey("IdEgn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theatre.Data.Models.Company", "Company")
                        .WithMany("MapingOwnerPersons")
                        .HasForeignKey("IdEik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Theatre.Data.Models.Company", b =>
                {
                    b.Navigation("MapingCompanyReports");

                    b.Navigation("MapingManagers");

                    b.Navigation("MapingOwnerCompanies");

                    b.Navigation("MapingOwnerPersons");
                });

            modelBuilder.Entity("Theatre.Data.Models.Kid", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("Theatre.Data.Models.Person", b =>
                {
                    b.Navigation("MapingManagers");

                    b.Navigation("MapingOwnerPersons");
                });
#pragma warning restore 612, 618
        }
    }
}
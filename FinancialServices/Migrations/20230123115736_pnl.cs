using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialServices.Migrations
{
    public partial class pnl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    CreditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEik = table.Column<long>(type: "bigint", nullable: false),
                    CreditNumber = table.Column<int>(type: "int", nullable: false),
                    BeginValue = table.Column<double>(type: "float", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    PresentValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.CreditId);
                });

            migrationBuilder.CreateTable(
                name: "Kids",
                columns: table => new
                {
                    KidNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kids", x => x.KidNumber);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    IdEgn = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.IdEgn);
                });

            migrationBuilder.CreateTable(
                name: "PNLs",
                columns: table => new
                {
                    idEikYear = table.Column<long>(type: "bigint", nullable: false),
                    Eik = table.Column<long>(type: "bigint", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    N10100 = table.Column<double>(type: "float", nullable: false),
                    N10200 = table.Column<double>(type: "float", nullable: false),
                    N10210 = table.Column<double>(type: "float", nullable: false),
                    N10220 = table.Column<double>(type: "float", nullable: false),
                    N10300 = table.Column<double>(type: "float", nullable: false),
                    N10310 = table.Column<double>(type: "float", nullable: false),
                    N10311 = table.Column<double>(type: "float", nullable: false),
                    N10320 = table.Column<double>(type: "float", nullable: false),
                    N10321 = table.Column<double>(type: "float", nullable: false),
                    N10400 = table.Column<double>(type: "float", nullable: false),
                    N10410 = table.Column<double>(type: "float", nullable: false),
                    N10411 = table.Column<double>(type: "float", nullable: false),
                    N10413 = table.Column<double>(type: "float", nullable: false),
                    N10412 = table.Column<double>(type: "float", nullable: false),
                    N10420 = table.Column<double>(type: "float", nullable: false),
                    N10500 = table.Column<double>(type: "float", nullable: false),
                    N10510 = table.Column<double>(type: "float", nullable: false),
                    N10520 = table.Column<double>(type: "float", nullable: false),
                    N10000 = table.Column<double>(type: "float", nullable: false),
                    N11100 = table.Column<double>(type: "float", nullable: false),
                    N11110 = table.Column<double>(type: "float", nullable: false),
                    N11200 = table.Column<double>(type: "float", nullable: false),
                    N11210 = table.Column<double>(type: "float", nullable: false),
                    N11220 = table.Column<double>(type: "float", nullable: false),
                    N11201 = table.Column<double>(type: "float", nullable: false),
                    N11000 = table.Column<double>(type: "float", nullable: false),
                    N14000 = table.Column<double>(type: "float", nullable: false),
                    N13000 = table.Column<double>(type: "float", nullable: false),
                    N14100 = table.Column<double>(type: "float", nullable: false),
                    N14200 = table.Column<double>(type: "float", nullable: false),
                    N14300 = table.Column<double>(type: "float", nullable: false),
                    N14400 = table.Column<double>(type: "float", nullable: false),
                    N14500 = table.Column<double>(type: "float", nullable: false),
                    N15100 = table.Column<double>(type: "float", nullable: false),
                    N15110 = table.Column<double>(type: "float", nullable: false),
                    N15120 = table.Column<double>(type: "float", nullable: false),
                    N15130 = table.Column<double>(type: "float", nullable: false),
                    N15131 = table.Column<double>(type: "float", nullable: false),
                    N15132 = table.Column<double>(type: "float", nullable: false),
                    N15133 = table.Column<double>(type: "float", nullable: false),
                    N15200 = table.Column<double>(type: "float", nullable: false),
                    N15300 = table.Column<double>(type: "float", nullable: false),
                    N15310 = table.Column<double>(type: "float", nullable: false),
                    N15400 = table.Column<double>(type: "float", nullable: false),
                    N15410 = table.Column<double>(type: "float", nullable: false),
                    N15411 = table.Column<double>(type: "float", nullable: false),
                    N15420 = table.Column<double>(type: "float", nullable: false),
                    N15430 = table.Column<double>(type: "float", nullable: false),
                    N15000 = table.Column<double>(type: "float", nullable: false),
                    N16100 = table.Column<double>(type: "float", nullable: false),
                    N16110 = table.Column<double>(type: "float", nullable: false),
                    N16200 = table.Column<double>(type: "float", nullable: false),
                    N16210 = table.Column<double>(type: "float", nullable: false),
                    N16300 = table.Column<double>(type: "float", nullable: false),
                    N16310 = table.Column<double>(type: "float", nullable: false),
                    N16320 = table.Column<double>(type: "float", nullable: false),
                    N16330 = table.Column<double>(type: "float", nullable: false),
                    N16000 = table.Column<double>(type: "float", nullable: false),
                    N19000 = table.Column<double>(type: "float", nullable: false),
                    N18000 = table.Column<double>(type: "float", nullable: false),
                    N19100 = table.Column<double>(type: "float", nullable: false),
                    N19200 = table.Column<double>(type: "float", nullable: false),
                    N19500 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PNLs", x => x.idEikYear);
                });

            migrationBuilder.CreateTable(
                name: "ReportDatas",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEik = table.Column<long>(type: "bigint", nullable: false),
                    YearReport = table.Column<int>(type: "int", nullable: false),
                    Assets = table.Column<double>(type: "float", nullable: false),
                    CountOfEmployees = table.Column<double>(type: "float", nullable: false),
                    AnnualTurnover = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDatas", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    IdEik = table.Column<long>(type: "bigint", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AddressCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KidNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Representing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeRepresenting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.IdEik);
                    table.ForeignKey(
                        name: "FK_Companies_Kids_KidNumber",
                        column: x => x.KidNumber,
                        principalTable: "Kids",
                        principalColumn: "KidNumber");
                });

            migrationBuilder.CreateTable(
                name: "MapingCompanyReports",
                columns: table => new
                {
                    IdEik = table.Column<long>(type: "bigint", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapingCompanyReports", x => new { x.IdEik, x.ReportId });
                    table.ForeignKey(
                        name: "FK_MapingCompanyReports_Companies_IdEik",
                        column: x => x.IdEik,
                        principalTable: "Companies",
                        principalColumn: "IdEik",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapingCompanyReports_ReportDatas_ReportId",
                        column: x => x.ReportId,
                        principalTable: "ReportDatas",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapingManagers",
                columns: table => new
                {
                    IdEik = table.Column<long>(type: "bigint", nullable: false),
                    IdEgn = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapingManagers", x => new { x.IdEik, x.IdEgn });
                    table.ForeignKey(
                        name: "FK_MapingManagers_Companies_IdEik",
                        column: x => x.IdEik,
                        principalTable: "Companies",
                        principalColumn: "IdEik",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapingManagers_Persons_IdEgn",
                        column: x => x.IdEgn,
                        principalTable: "Persons",
                        principalColumn: "IdEgn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapingOwnerCompanies",
                columns: table => new
                {
                    IdEik = table.Column<long>(type: "bigint", nullable: false),
                    IdEikOwner = table.Column<long>(type: "bigint", nullable: false),
                    Persent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapingOwnerCompanies", x => new { x.IdEik, x.IdEikOwner });
                    table.ForeignKey(
                        name: "FK_MapingOwnerCompanies_Companies_IdEik",
                        column: x => x.IdEik,
                        principalTable: "Companies",
                        principalColumn: "IdEik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapingOwnerPersons",
                columns: table => new
                {
                    IdEik = table.Column<long>(type: "bigint", nullable: false),
                    IdEgn = table.Column<long>(type: "bigint", nullable: false),
                    Persent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapingOwnerPersons", x => new { x.IdEik, x.IdEgn });
                    table.ForeignKey(
                        name: "FK_MapingOwnerPersons_Companies_IdEik",
                        column: x => x.IdEik,
                        principalTable: "Companies",
                        principalColumn: "IdEik",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapingOwnerPersons_Persons_IdEgn",
                        column: x => x.IdEgn,
                        principalTable: "Persons",
                        principalColumn: "IdEgn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_KidNumber",
                table: "Companies",
                column: "KidNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MapingCompanyReports_ReportId",
                table: "MapingCompanyReports",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_MapingManagers_IdEgn",
                table: "MapingManagers",
                column: "IdEgn");

            migrationBuilder.CreateIndex(
                name: "IX_MapingOwnerPersons_IdEgn",
                table: "MapingOwnerPersons",
                column: "IdEgn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "MapingCompanyReports");

            migrationBuilder.DropTable(
                name: "MapingManagers");

            migrationBuilder.DropTable(
                name: "MapingOwnerCompanies");

            migrationBuilder.DropTable(
                name: "MapingOwnerPersons");

            migrationBuilder.DropTable(
                name: "PNLs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ReportDatas");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Kids");
        }
    }
}

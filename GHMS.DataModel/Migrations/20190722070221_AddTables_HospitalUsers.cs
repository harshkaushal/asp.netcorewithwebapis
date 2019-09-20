using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GHMS.DataModel.Migrations
{
    public partial class AddTables_HospitalUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 200, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 200, nullable: true),
                    Zip = table.Column<string>(maxLength: 6, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_AspNetUsers_LastUpdateUserId",
                        column: x => x.LastUpdateUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitals_AspNetUsers_LastUpdateUserId",
                        column: x => x.LastUpdateUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HospitalUserDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AspNetUserId = table.Column<string>(maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalUserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalUserDetails_AspNetUsers_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalUserDetails_AspNetUsers_LastUpdateUserId",
                        column: x => x.LastUpdateUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LuContactTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuContactTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LuContactTypes_AspNetUsers_LastUpdateUserId",
                        column: x => x.LastUpdateUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddressAudits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ModifiedUserId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 200, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 200, nullable: true),
                    Zip = table.Column<string>(maxLength: 6, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    AddressId = table.Column<long>(nullable: false),
                    AddressId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressAudits_Address_AddressId1",
                        column: x => x.AddressId1,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddressAudits_AspNetUsers_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HospitalsAudits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ModifiedUserId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    HospitalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalsAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalsAudits_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalsAudits_AspNetUsers_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HospitalUserDetailsAudits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ModifiedUserId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    HospitalUserDetailsId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalUserDetailsAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalUserDetailsAudits_HospitalUserDetails_HospitalUserD~",
                        column: x => x.HospitalUserDetailsId,
                        principalTable: "HospitalUserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalUserDetailsAudits_AspNetUsers_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LnkHospitalUserAddress",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    HospitalUserDetailsId = table.Column<int>(nullable: false),
                    HospitalUserDetailsId1 = table.Column<long>(nullable: true),
                    AddressId = table.Column<long>(nullable: false),
                    AddressId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LnkHospitalUserAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LnkHospitalUserAddress_Address_AddressId1",
                        column: x => x.AddressId1,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LnkHospitalUserAddress_HospitalUserDetails_HospitalUserDeta~",
                        column: x => x.HospitalUserDetailsId1,
                        principalTable: "HospitalUserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LnkHospitalUserAddress_AspNetUsers_LastUpdateUserId",
                        column: x => x.LastUpdateUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HospitalUserContacts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    HospitalUserDetailsId = table.Column<int>(nullable: false),
                    HospitalUserDetailsId1 = table.Column<long>(nullable: true),
                    Contact = table.Column<string>(maxLength: 100, nullable: false),
                    ContactTypesId = table.Column<int>(nullable: false),
                    ContactTypesId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalUserContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalUserContacts_LuContactTypes_ContactTypesId1",
                        column: x => x.ContactTypesId1,
                        principalTable: "LuContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalUserContacts_HospitalUserDetails_HospitalUserDetail~",
                        column: x => x.HospitalUserDetailsId1,
                        principalTable: "HospitalUserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalUserContacts_AspNetUsers_LastUpdateUserId",
                        column: x => x.LastUpdateUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LuContactTypesAudits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ModifiedUserId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    ContactTypesId = table.Column<int>(nullable: false),
                    ContactTypesId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuContactTypesAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LuContactTypesAudits_LuContactTypes_ContactTypesId1",
                        column: x => x.ContactTypesId1,
                        principalTable: "LuContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LuContactTypesAudits_AspNetUsers_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LnkHospitalUserAddressAudits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ModifiedUserId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    HospitalUserDetailsId = table.Column<int>(nullable: false),
                    AddressId = table.Column<long>(nullable: false),
                    LnkHospitalUserAddressId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LnkHospitalUserAddressAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LnkHospitalUserAddressAudits_LnkHospitalUserAddress_LnkHosp~",
                        column: x => x.LnkHospitalUserAddressId,
                        principalTable: "LnkHospitalUserAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LnkHospitalUserAddressAudits_AspNetUsers_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HospitalUserContactsAudits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ModifiedUserId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    HospitalUserDetailsId = table.Column<int>(nullable: false),
                    HospitalUserDetailsId1 = table.Column<long>(nullable: true),
                    Contact = table.Column<string>(maxLength: 100, nullable: false),
                    ContactTypesId = table.Column<int>(nullable: false),
                    ContactTypesId1 = table.Column<long>(nullable: true),
                    HospitalUserContactsId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalUserContactsAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalUserContactsAudits_LuContactTypes_ContactTypesId1",
                        column: x => x.ContactTypesId1,
                        principalTable: "LuContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalUserContactsAudits_HospitalUserContacts_HospitalUse~",
                        column: x => x.HospitalUserContactsId,
                        principalTable: "HospitalUserContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalUserContactsAudits_HospitalUserDetails_HospitalUser~",
                        column: x => x.HospitalUserDetailsId1,
                        principalTable: "HospitalUserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalUserContactsAudits_AspNetUsers_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_LastUpdateUserId",
                table: "Address",
                column: "LastUpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressAudits_AddressId1",
                table: "AddressAudits",
                column: "AddressId1");

            migrationBuilder.CreateIndex(
                name: "IX_AddressAudits_ModifiedUserId",
                table: "AddressAudits",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_LastUpdateUserId",
                table: "Hospitals",
                column: "LastUpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalsAudits_HospitalId",
                table: "HospitalsAudits",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalsAudits_ModifiedUserId",
                table: "HospitalsAudits",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserContacts_ContactTypesId1",
                table: "HospitalUserContacts",
                column: "ContactTypesId1");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserContacts_HospitalUserDetailsId1",
                table: "HospitalUserContacts",
                column: "HospitalUserDetailsId1");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserContacts_LastUpdateUserId",
                table: "HospitalUserContacts",
                column: "LastUpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserContactsAudits_ContactTypesId1",
                table: "HospitalUserContactsAudits",
                column: "ContactTypesId1");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserContactsAudits_HospitalUserContactsId",
                table: "HospitalUserContactsAudits",
                column: "HospitalUserContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserContactsAudits_HospitalUserDetailsId1",
                table: "HospitalUserContactsAudits",
                column: "HospitalUserDetailsId1");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserContactsAudits_ModifiedUserId",
                table: "HospitalUserContactsAudits",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserDetails_AspNetUserId",
                table: "HospitalUserDetails",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserDetails_LastUpdateUserId",
                table: "HospitalUserDetails",
                column: "LastUpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserDetailsAudits_HospitalUserDetailsId",
                table: "HospitalUserDetailsAudits",
                column: "HospitalUserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserDetailsAudits_ModifiedUserId",
                table: "HospitalUserDetailsAudits",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LnkHospitalUserAddress_AddressId1",
                table: "LnkHospitalUserAddress",
                column: "AddressId1");

            migrationBuilder.CreateIndex(
                name: "IX_LnkHospitalUserAddress_HospitalUserDetailsId1",
                table: "LnkHospitalUserAddress",
                column: "HospitalUserDetailsId1");

            migrationBuilder.CreateIndex(
                name: "IX_LnkHospitalUserAddress_LastUpdateUserId",
                table: "LnkHospitalUserAddress",
                column: "LastUpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LnkHospitalUserAddressAudits_LnkHospitalUserAddressId",
                table: "LnkHospitalUserAddressAudits",
                column: "LnkHospitalUserAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_LnkHospitalUserAddressAudits_ModifiedUserId",
                table: "LnkHospitalUserAddressAudits",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LuContactTypes_LastUpdateUserId",
                table: "LuContactTypes",
                column: "LastUpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LuContactTypesAudits_ContactTypesId1",
                table: "LuContactTypesAudits",
                column: "ContactTypesId1");

            migrationBuilder.CreateIndex(
                name: "IX_LuContactTypesAudits_ModifiedUserId",
                table: "LuContactTypesAudits",
                column: "ModifiedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressAudits");

            migrationBuilder.DropTable(
                name: "HospitalsAudits");

            migrationBuilder.DropTable(
                name: "HospitalUserContactsAudits");

            migrationBuilder.DropTable(
                name: "HospitalUserDetailsAudits");

            migrationBuilder.DropTable(
                name: "LnkHospitalUserAddressAudits");

            migrationBuilder.DropTable(
                name: "LuContactTypesAudits");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "HospitalUserContacts");

            migrationBuilder.DropTable(
                name: "LnkHospitalUserAddress");

            migrationBuilder.DropTable(
                name: "LuContactTypes");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "HospitalUserDetails");
        }
    }
}

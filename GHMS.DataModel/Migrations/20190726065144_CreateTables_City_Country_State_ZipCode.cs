using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GHMS.DataModel.Migrations
{
    public partial class CreateTables_City_Country_State_ZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalUserContacts_LuContactTypes_ContactTypesId1",
                table: "HospitalUserContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalUserContactsAudits_LuContactTypes_ContactTypesId1",
                table: "HospitalUserContactsAudits");

            migrationBuilder.DropForeignKey(
                name: "FK_LuContactTypesAudits_LuContactTypes_ContactTypesId1",
                table: "LuContactTypesAudits");

            migrationBuilder.DropIndex(
                name: "IX_LuContactTypesAudits_ContactTypesId1",
                table: "LuContactTypesAudits");

            migrationBuilder.DropIndex(
                name: "IX_HospitalUserContactsAudits_ContactTypesId1",
                table: "HospitalUserContactsAudits");

            migrationBuilder.DropIndex(
                name: "IX_HospitalUserContacts_ContactTypesId1",
                table: "HospitalUserContacts");

            migrationBuilder.DropColumn(
                name: "ContactTypesId1",
                table: "LuContactTypesAudits");

            migrationBuilder.DropColumn(
                name: "ContactTypesId1",
                table: "HospitalUserContactsAudits");

            migrationBuilder.DropColumn(
                name: "ContactTypesId1",
                table: "HospitalUserContacts");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LuContactTypes",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "Address",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Address",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Address",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LuCountries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LuCountries_AspNetUsers_LastUpdateUserId",
                        column: x => x.LastUpdateUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LuCountriesAudits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ModifiedUserId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuCountriesAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LuCountriesAudits_LuCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "LuCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LuCountriesAudits_AspNetUsers_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LuStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LuStates_LuCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "LuCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LuStates_AspNetUsers_LastUpdateUserId",
                        column: x => x.LastUpdateUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LuCities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 100, nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LuCities_AspNetUsers_LastUpdateUserId",
                        column: x => x.LastUpdateUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LuCities_LuStates_StateId",
                        column: x => x.StateId,
                        principalTable: "LuStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LuStatesAudits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LastUpdateUserId = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ModifiedUserId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuStatesAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LuStatesAudits_AspNetUsers_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LuStatesAudits_LuStates_StateId",
                        column: x => x.StateId,
                        principalTable: "LuStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LuCitiesAudits",
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
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 100, nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    CityId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuCitiesAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LuCitiesAudits_LuCities_CityId1",
                        column: x => x.CityId1,
                        principalTable: "LuCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LuCitiesAudits_AspNetUsers_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LuContactTypes",
                columns: new[] { "Id", "Description", "IsActive", "LastUpdateDate", "LastUpdateUserId", "Name" },
                values: new object[,]
                {
                    { 1, "Phone Number", true, new DateTime(2019, 7, 26, 12, 21, 42, 899, DateTimeKind.Local).AddTicks(7926), null, "Phone Number" },
                    { 2, "Email", true, new DateTime(2019, 7, 26, 12, 21, 42, 901, DateTimeKind.Local).AddTicks(595), null, "Email" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LuContactTypesAudits_ContactTypesId",
                table: "LuContactTypesAudits",
                column: "ContactTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserContactsAudits_ContactTypesId",
                table: "HospitalUserContactsAudits",
                column: "ContactTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserContacts_ContactTypesId",
                table: "HospitalUserContacts",
                column: "ContactTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateId",
                table: "Address",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_LuCities_LastUpdateUserId",
                table: "LuCities",
                column: "LastUpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LuCities_StateId",
                table: "LuCities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_LuCitiesAudits_CityId1",
                table: "LuCitiesAudits",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_LuCitiesAudits_ModifiedUserId",
                table: "LuCitiesAudits",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LuCountries_LastUpdateUserId",
                table: "LuCountries",
                column: "LastUpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LuCountriesAudits_CountryId",
                table: "LuCountriesAudits",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_LuCountriesAudits_ModifiedUserId",
                table: "LuCountriesAudits",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LuStates_CountryId",
                table: "LuStates",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_LuStates_LastUpdateUserId",
                table: "LuStates",
                column: "LastUpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LuStatesAudits_ModifiedUserId",
                table: "LuStatesAudits",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LuStatesAudits_StateId",
                table: "LuStatesAudits",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_LuCities_CityId",
                table: "Address",
                column: "CityId",
                principalTable: "LuCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_LuCountries_CountryId",
                table: "Address",
                column: "CountryId",
                principalTable: "LuCountries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_LuStates_StateId",
                table: "Address",
                column: "StateId",
                principalTable: "LuStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalUserContacts_LuContactTypes_ContactTypesId",
                table: "HospitalUserContacts",
                column: "ContactTypesId",
                principalTable: "LuContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalUserContactsAudits_LuContactTypes_ContactTypesId",
                table: "HospitalUserContactsAudits",
                column: "ContactTypesId",
                principalTable: "LuContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LuContactTypesAudits_LuContactTypes_ContactTypesId",
                table: "LuContactTypesAudits",
                column: "ContactTypesId",
                principalTable: "LuContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_LuCities_CityId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_LuCountries_CountryId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_LuStates_StateId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalUserContacts_LuContactTypes_ContactTypesId",
                table: "HospitalUserContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalUserContactsAudits_LuContactTypes_ContactTypesId",
                table: "HospitalUserContactsAudits");

            migrationBuilder.DropForeignKey(
                name: "FK_LuContactTypesAudits_LuContactTypes_ContactTypesId",
                table: "LuContactTypesAudits");

            migrationBuilder.DropTable(
                name: "LuCitiesAudits");

            migrationBuilder.DropTable(
                name: "LuCountriesAudits");

            migrationBuilder.DropTable(
                name: "LuStatesAudits");

            migrationBuilder.DropTable(
                name: "LuCities");

            migrationBuilder.DropTable(
                name: "LuStates");

            migrationBuilder.DropTable(
                name: "LuCountries");

            migrationBuilder.DropIndex(
                name: "IX_LuContactTypesAudits_ContactTypesId",
                table: "LuContactTypesAudits");

            migrationBuilder.DropIndex(
                name: "IX_HospitalUserContactsAudits_ContactTypesId",
                table: "HospitalUserContactsAudits");

            migrationBuilder.DropIndex(
                name: "IX_HospitalUserContacts_ContactTypesId",
                table: "HospitalUserContacts");

            migrationBuilder.DropIndex(
                name: "IX_Address_CityId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_CountryId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StateId",
                table: "Address");

            migrationBuilder.DeleteData(
                table: "LuContactTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LuContactTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Address");

            migrationBuilder.AddColumn<long>(
                name: "ContactTypesId1",
                table: "LuContactTypesAudits",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "LuContactTypes",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<long>(
                name: "ContactTypesId1",
                table: "HospitalUserContactsAudits",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ContactTypesId1",
                table: "HospitalUserContacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Address",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Address",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Address",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_LuContactTypesAudits_ContactTypesId1",
                table: "LuContactTypesAudits",
                column: "ContactTypesId1");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserContactsAudits_ContactTypesId1",
                table: "HospitalUserContactsAudits",
                column: "ContactTypesId1");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUserContacts_ContactTypesId1",
                table: "HospitalUserContacts",
                column: "ContactTypesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalUserContacts_LuContactTypes_ContactTypesId1",
                table: "HospitalUserContacts",
                column: "ContactTypesId1",
                principalTable: "LuContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalUserContactsAudits_LuContactTypes_ContactTypesId1",
                table: "HospitalUserContactsAudits",
                column: "ContactTypesId1",
                principalTable: "LuContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LuContactTypesAudits_LuContactTypes_ContactTypesId1",
                table: "LuContactTypesAudits",
                column: "ContactTypesId1",
                principalTable: "LuContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

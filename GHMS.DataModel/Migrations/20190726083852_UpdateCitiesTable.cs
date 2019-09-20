using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GHMS.DataModel.Migrations
{
    public partial class UpdateCitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "LuCitiesAudits");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "LuCities");

            migrationBuilder.UpdateData(
                table: "LuContactTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdateDate",
                value: new DateTime(2019, 7, 26, 14, 8, 50, 606, DateTimeKind.Local).AddTicks(937));

            migrationBuilder.UpdateData(
                table: "LuContactTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdateDate",
                value: new DateTime(2019, 7, 26, 14, 8, 50, 608, DateTimeKind.Local).AddTicks(719));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "LuCitiesAudits",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "LuCities",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "LuContactTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdateDate",
                value: new DateTime(2019, 7, 26, 13, 30, 27, 633, DateTimeKind.Local).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "LuContactTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdateDate",
                value: new DateTime(2019, 7, 26, 13, 30, 27, 634, DateTimeKind.Local).AddTicks(8807));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GHMS.DataModel.Migrations
{
    public partial class usp_getlookuptables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE OR REPLACE FUNCTION public.usp_getlookuptables(
	                )
                    RETURNS TABLE(tablename text, displayname text) 
                    LANGUAGE 'plpgsql'
 
                AS $BODY$
                BEGIN
                 RETURN QUERY
                 
                 select table_name::text as TableName,''::text as DisplayName from information_schema.tables
                  where table_name like 'Lu%' and table_name not LIKE  '%Audits';
                 
                END; $BODY$;"
            );
 

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Message = table.Column<string>(nullable: true),
                    MessageTemplate = table.Column<string>(nullable: true),
                    Project = table.Column<string>(maxLength: 128, nullable: true),
                    ControllerName = table.Column<string>(maxLength: 128, nullable: true),
                    ActionName = table.Column<string>(maxLength: 128, nullable: true),
                    AspNetUserId = table.Column<string>(maxLength: 450, nullable: true),
                    Level = table.Column<string>(maxLength: 128, nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Exception = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(type: "xml", nullable: true),
                    LogEvent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

       
        }
    }
}

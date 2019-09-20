using Microsoft.EntityFrameworkCore.Migrations;

namespace GHMS.DataModel.Migrations
{
    public partial class usp_gettableschemainfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE OR REPLACE FUNCTION public.usp_gettableschemainfo(
	tablename text)
    RETURNS TABLE(columnname text, displayname text, DataType text, constraintname text, foreigntablename text, foreigncolumnname text) 
    LANGUAGE 'plpgsql'
 
AS $BODY$
                BEGIN
                 RETURN QUERY
                 
                 select 
	c.column_name::text as ColumnName,
	''::text DisplayName,
	c.data_type::text as DataType,
	kcu.constraint_name::text as ConstraintName,
	--kcu.table_name as Table_Name,
	--ccu.table_schema AS ForeignTableSchema,
	ccu.table_name::text AS ForeignTableName,
	ccu.column_name::text AS ForeignColumnName  
from information_schema.columns c
            left join information_schema.key_column_usage kcu

            on c.table_name = kcu.table_name AND c.column_name = kcu.column_name
            left join information_schema.table_constraints tc

            on tc.constraint_name = kcu.constraint_name AND tc.table_name = kcu.table_name AND tc.constraint_type = 'FOREIGN KEY'
            left join information_schema.constraint_column_usage ccu

            on  tc.constraint_name = ccu.constraint_name
            WHERE c.table_name = tableName;


            END; $BODY$; "
            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

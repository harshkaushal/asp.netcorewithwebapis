using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GHMS.DataModel.Data;
using GHMS.DataModel.Models.Common;
using GHMS.Repository.Abstract;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using GHMS.Core.Helper;
using GHMS.ViewModel.APIModels;
using System.Data.SqlClient;
using Npgsql;

namespace GHMS.Repository.Concrete
{
    public class AdminRepository : IAdminRepository
    {
        private readonly GHMSDbContext _context;
           public AdminRepository(GHMSDbContext context, UserManager<ApplicationUser> userManager)
        {
              _context = context;
        }

           public async Task<List<GetAllLookUpTables>> GetAllLookUpTables()
           {
               try
               {
                   List<GetAllLookUpTables> result;
                   _context.Database.OpenConnection();

                   using (var command = _context.Database.GetDbConnection().CreateCommand())
                   {
                       //command.CommandText = @"select table_name as TableName,'' as DisplayName from information_schema.tables
                       //            where table_name like 'Lu%' and table_name not LIKE  '%Audits'";
                       //command.CommandType = CommandType.Text;
                       command.CommandText = @"usp_GetLookUpTables";
                       command.CommandType = CommandType.StoredProcedure;

                       using (var reader = await command.ExecuteReaderAsync())
                       {
                           result = reader.MapToList<GetAllLookUpTables>().ToList();
                       }
                   }

                   _context.Database.CloseConnection();
                   return result;
               }
               catch (Exception ex)
               {
                   throw ex;
               }
           }
           public async Task<List<GetTableSchemaInfo>> GetTableSchemaInfo(String tableName)
           {
               try
               {
                   List<GetTableSchemaInfo> result;
                   _context.Database.OpenConnection();

                   using (var command = _context.Database.GetDbConnection().CreateCommand())
                   {
                       NpgsqlParameter param = new NpgsqlParameter();
                       param.ParameterName = "tablename";
                       param.Value = tableName;
                       command.Parameters.Add(param);
                    command.CommandText = @"usp_GetTableSchemaInfo";
                       command.CommandType = CommandType.StoredProcedure;
                       using (var reader = await command.ExecuteReaderAsync())
                       {
                           result = reader.MapToList<GetTableSchemaInfo>().ToList();
                       }
                   }
                   _context.Database.CloseConnection();
                   return result;
               }
               catch (Exception ex)
               {
                   throw ex;
               }
           }
    }
}
using GHMS.Repository.Abstract;
using GHMS.Service.Abstract;
using GHMS.ViewModel.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace GHMS.Service.Concrete
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(
            IAdminRepository adminRepository
        )
        {
            _adminRepository = adminRepository;
        }

        public async Task<List<GetAllLookUpTables>> GetAllLookUpTables()
        {
            try
            {
                var res = await _adminRepository.GetAllLookUpTables();
                return res.Select(a => new GetAllLookUpTables
                {
                    TableName = a.TableName,
                    DisplayName = Regex.Replace(a.TableName.Replace("Lu", "").Replace("lu", ""), "(\\B[A-Z])", " $1")
                }).ToList();
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
                var res = await _adminRepository.GetTableSchemaInfo(tableName);
                return res.Select(a => new GetTableSchemaInfo
                {
                    ColumnName = a.ColumnName,
                    DisplayName = Regex.Replace(a.ColumnName, "(\\B[A-Z])", " $1"),
                    ConstraintName = a.ConstraintName,
                    DataType = a.DataType,
                    ForeignColumnName = a.ForeignColumnName,
                    ForeignTableName = a.ForeignTableName
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
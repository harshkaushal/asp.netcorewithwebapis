using GHMS.ViewModel.APIModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHMS.Service.Abstract
{
    public interface IAdminService
    {
        Task<List<GetAllLookUpTables>> GetAllLookUpTables();
        Task<List<GetTableSchemaInfo>> GetTableSchemaInfo(String tableName);
    }
}
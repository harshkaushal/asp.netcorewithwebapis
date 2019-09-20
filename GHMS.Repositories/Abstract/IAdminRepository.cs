using GHMS.ViewModel.APIModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHMS.Repository.Abstract
{
    public interface IAdminRepository
    {
        Task<List<GetAllLookUpTables>> GetAllLookUpTables();
        Task<List<GetTableSchemaInfo>> GetTableSchemaInfo(String tableName);
    }
}
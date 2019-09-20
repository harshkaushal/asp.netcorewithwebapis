using System.Collections.Generic;

namespace GHMS.ViewModel.APIModels
{
    public class GetAllLookUpTablesResponse : BaseResponse
    {
        public List<GetAllLookUpTables> ResponseData { get; set; }
    }
    public class GetAllLookUpTables
    {
        public string TableName { get; set; }
        public string DisplayName { get; set; }       
    }
}

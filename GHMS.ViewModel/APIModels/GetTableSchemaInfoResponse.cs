using System;
using System.Collections.Generic;

namespace GHMS.ViewModel.APIModels
{
    public class GetTableSchemaInfoResponse : BaseResponse
    {
        public List<GetTableSchemaInfo> ResponseData { get; set; }
    }
    public class GetTableSchemaInfo
    {
        public string ColumnName { get; set; }
        public String DisplayName { get; set; }
        public String DataType { get; set; }
        public String ConstraintName { get; set; }
        public String ForeignTableName { get; set; }
        public String ForeignColumnName { get; set; }
    }
}

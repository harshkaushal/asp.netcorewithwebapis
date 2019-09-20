using GHMS.Core;
using System;
using System.Collections.Generic;
using System.Text; 

namespace GHMS.ViewModel.APIModels
{
    public class BaseResponse
    {
        public ResponseCodes ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}

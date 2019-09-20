using System;
using System.Collections.Generic;
using System.Text;
//using Microsoft.Extensions.Logging;
using Serilog;


namespace GHSM.Core.Serilog
{
    public   class SerilogLogs
    { 
        public   SerilogLogs() { }
       
        public static void LogError(String ProjectName, String ControllerName, String ActionName, String AspNetUserId,
            Exception ex, bool IsThrowException = false )
        {
          
            Log.Logger.ForContext("Project", ProjectName)
                .ForContext("ControllerName", ControllerName)
                .ForContext("ActionName", ActionName)
                .ForContext("AspNetUserId", AspNetUserId)
               .ForContext("Exception", ex)
                .Error(ex.Message, ex);
            Log.CloseAndFlush();
            if (IsThrowException)
                throw ex;
           
        }
    }
}

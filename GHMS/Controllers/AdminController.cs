using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GHMS.Core;
using GHMS.Core.Helper;
using GHMS.Core.Settings;
using GHMS.Service.Abstract;
using GHMS.ViewModel.APIModels;
using GHSM.Core.Serilog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GHMS.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private IAdminService _adminService;
              private JWTSettings JWTSettings { get; }
        private AppSettings AppSettings { get; }
        public AdminController(
             IAdminService adminService
                  , IOptions<JWTSettings> jwtSettings
             , IOptions<AppSettings> appSettings
        
        )
        {
            _adminService = adminService;
              JWTSettings = jwtSettings?.Value;
            AppSettings = appSettings?.Value;
        }
        [Route("~/api/GetAllLookUpTables")]
        [HttpGet]
         [Authorize]
        [ProducesResponseType(typeof(GetAllLookUpTablesResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllLookUpTables()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GetAllLookUpTablesResponse response=new GetAllLookUpTablesResponse();
                    var res = await _adminService.GetAllLookUpTables();
                    response.ResponseData = res;
                    response.ResponseCode = ResponseCodes.Success;
                    response.ResponseMessage = SystemMessagesHelper.RecordsReturnedSuccessfully;
                    return Ok(response);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                SerilogLogs.LogError(SerilogKeywordProject.GHMS, SerilogKeywordController.Admin, SerilogKeywordAction.Login, null, ex);
                return StatusCode((int)ResponseCodes.Error);
            }
        }

        [Route("~/api/GetTableSchemaInfo")]
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(typeof(GetTableSchemaInfoResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTableSchemaInfo(String tableName)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GetTableSchemaInfoResponse response = new GetTableSchemaInfoResponse();
                    var res = await _adminService.GetTableSchemaInfo(tableName);
                    response.ResponseData = res;
                    response.ResponseCode = ResponseCodes.Success;
                    response.ResponseMessage = SystemMessagesHelper.RecordsReturnedSuccessfully;
                    return Ok(response);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                SerilogLogs.LogError(SerilogKeywordProject.GHMS, SerilogKeywordController.Admin, SerilogKeywordAction.Login, null, ex);
                return StatusCode((int)ResponseCodes.Error);
            }
        }

    }
}

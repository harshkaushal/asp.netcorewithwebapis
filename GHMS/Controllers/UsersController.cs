using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GHMS.Core;
using GHMS.Service.Abstract;
using GHSM.Core.Serilog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GHMS.Controllers
{
    
   
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUsersService _usersService;
        public UsersController(
             IUsersService usersService
        )
        {
            _usersService = usersService;
        }
        [Route("~/api/GetAspNetRoles")]
        [HttpGet]
        [ProducesResponseType(typeof(IdentityRole), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAspNetRoles()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res =   _usersService.GetAspNetRoles();
                    return Ok(res);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                //SerilogLogs.LogError(SerilogKeywordProject.TemplarAPI, SerilogKeywordController.Account, SerilogKeywordAction.Login, null, null, null, ex);

                return StatusCode((int)ResponseCodes.Error);
            }
        }
    }
}

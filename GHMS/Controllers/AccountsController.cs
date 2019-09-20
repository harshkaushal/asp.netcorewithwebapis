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
    public class AccountsController : Controller
    {
        private IUsersService _usersService;
        private IHospitalService _hospitalService;
           private JWTSettings JWTSettings { get; }
        private AppSettings AppSettings { get; }
        public AccountsController(
             IUsersService usersService
             , IHospitalService hospitalService
             , IOptions<JWTSettings> jwtSettings
             , IOptions<AppSettings> appSettings
        
        )
        {
            _usersService = usersService;
            _hospitalService = hospitalService;      
            JWTSettings = jwtSettings?.Value;
            AppSettings = appSettings?.Value;
        }
        [Route("~/api/Login")]
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody]LoginRequest login)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    IActionResult response = Unauthorized();
                    var res = await AuthenticateUser(login);
                    return Ok(res);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                SerilogLogs.LogError(SerilogKeywordProject.GHMS, SerilogKeywordController.Account, SerilogKeywordAction.Login, null, ex);
                return StatusCode((int)ResponseCodes.Error);
            }
        }

        [Route("~/api/SignOut")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
             await _usersService.SignOut();
            return Ok();
        }

        #region Common Methods

        private string GenerateJSONWebToken(LoginRequest login, string[] roles, UserInfo userData)
        {

            // authentication successful so generate jwt token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
               var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userData.Id),
              new Claim("HospitalCode",login.HospitalCode.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");
            // Adding roles code
            // Roles property is string collection but you can modify Select code if it it's not
            claimsIdentity.AddClaims(roles.Select(role => new Claim(ClaimTypes.Role, role)));
           var token = new JwtSecurityToken(issuer: JWTSettings.Issuer,
               audience: JWTSettings.Issuer,
                claims: claimsIdentity.Claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(JWTSettings.TokenExpiry_Minutes),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private async Task<LoginResponse> AuthenticateUser(LoginRequest login)
        {
            LoginResponse response = new LoginResponse();
            if (AppSettings.SuperAdminHospitalCode.ToLower() == login.HospitalCode.ToLower()
            ||  await _hospitalService.CheckHospitalCode(login.HospitalCode))
            {
                string userName = AppSettings.SuperAdminHospitalCode.ToLower() == login.HospitalCode.ToLower()
                    ? login.Username
                    : login.HospitalCode + "|" + login.Username;

                login.Username = userName;
                var user = await _usersService.UserNameExists(userName);
                if (user)
                {
                    login.Password = login.Password.Trim();
                    var result = await _usersService.PasswordSignIn(login);
                    if (result.Succeeded)
                    {
                        var userData = await _usersService.GetUserInfoByUserName(userName);
                        userData.Token = GenerateJSONWebToken(login, userData.UserRoles.ToArray(), userData);
                        response.ResponseData = userData;
                        response.ResponseCode = ResponseCodes.Success;
                        response.ResponseMessage = SystemMessagesHelper.UserLoginSuccessfully;
                    }
                    else if (result.IsLockedOut)
                    {
                        response.ResponseCode = ResponseCodes.InvalidModel;
                        response.ResponseMessage = SystemMessagesHelper.AccountLocked;
                    }
                    else
                    {
                        response.ResponseCode = ResponseCodes.InvalidModel;
                        response.ResponseMessage = SystemMessagesHelper.UserLoginFailed;
                    }
                }
                else
                {
                    response.ResponseCode = ResponseCodes.InvalidModel;
                    response.ResponseMessage = SystemMessagesHelper.UserLoginFailed;
                }
            }
            else
            {
                response.ResponseCode = ResponseCodes.InvalidModel;
                response.ResponseMessage = SystemMessagesHelper.UserLoginFailed;
            }
            return response;

        }
        #endregion
    }
}

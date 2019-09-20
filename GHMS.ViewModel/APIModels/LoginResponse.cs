using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GHMS.ViewModel.APIModels
{
    public class LoginResponse:BaseResponse
    {
        public UserInfo ResponseData { get; set; }
    }

    public class UserInfo
    {
        public string Id{ get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
        public string[] UserRoles { get; set; }
    }
}

using GHMS.ViewModel.APIModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHMS.Repository.Abstract
{
    public interface IUsersRepository
    {
        List<IdentityRole> GetAspNetRoles();
        Task SignOut();
        Task<IList<String>> GetUserRolesByUsername(string username);
        Task<bool> UserNameExists(string username);
        Task<SignInResult> PasswordSignIn(LoginRequest login);
        Task<UserInfo> GetUserInfoByUserName(string username);
    }
}
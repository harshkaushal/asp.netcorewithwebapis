using GHMS.DataModel.Data;
using GHMS.DataModel.Models.Common;
using GHMS.Repository.Abstract;
using GHMS.ViewModel.APIModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GHMS.Repository.Concrete
{
    public class UsersRepository : IUsersRepository
    {
        private readonly GHMSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersRepository(GHMSDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        public List<IdentityRole> GetAspNetRoles()
        {
            return _context.Roles.ToList();
        }

        public async Task SignOut()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<String>> GetUserRolesByUsername(string username)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                return await _userManager.GetRolesAsync(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UserNameExists(string username)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);

                if (user == null)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<UserInfo> GetUserInfoByUserName(string username)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                var roles = await _userManager.GetRolesAsync(user);

                var userData = new UserInfo
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Id = user.Id,
                    UserRoles = roles.ToArray()

                };
                return userData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // public async Task<Tuple<bool, UserInfo>> PasswordSignIn(LoginRequest login)
        public async Task<SignInResult> PasswordSignIn(LoginRequest login)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(login.Username, login.Password, false,
                    lockoutOnFailure: false);
                 return result;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
using GHMS.DataModel.Models.Common;
using GHMS.Repository.Abstract;
using GHMS.Service.Abstract;
using GHMS.ViewModel.APIModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace GHMS.Service.Concrete
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUsersRepository _usersRepository;

        public UsersService(
             IUsersRepository usersRepository
              , UserManager<ApplicationUser> userManager
            )
        {
            _userManager = userManager;
            _usersRepository = usersRepository;
        }

        public List<IdentityRole> GetAspNetRoles()
        {
            try
            {
                return _usersRepository.GetAspNetRoles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task SignOut()
        {
            try
            {
                await _usersRepository.SignOut();
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
                return await _usersRepository.GetUserRolesByUsername(username);
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
                return await _usersRepository.UserNameExists(username);
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
                return await _usersRepository.GetUserInfoByUserName(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<SignInResult> PasswordSignIn(LoginRequest login)
        {
            try
            {
                return await _usersRepository.PasswordSignIn(login);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
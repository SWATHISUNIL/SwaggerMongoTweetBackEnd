using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApplication.Interface;
using TweetApplication.Models;

namespace TweetApplication.Services
{
    public class UserService : IuserService
    {
        private readonly ISqlRepository sqlRepository;
        //dependency injection
        public UserService(ISqlRepository _sqlRepository)
        {
            sqlRepository = _sqlRepository;
        }
        public async Task<UserInfo> LoginUser(LoginModel loginInfo)
        {
            try
            {
                var user = await sqlRepository.GetUserByEmailId(loginInfo.emailId);
                if (user.Password.Trim() == loginInfo.password)
                {
                    user.Password = "";
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;

            }


        }

        public async Task<UserInfo> RegisterUser(UserInfo userInfo)
        {
            try
            {
                var existingUser= await sqlRepository.GetUserByEmailId(userInfo.Email);
                if (existingUser == null)
                {
                    var user = await sqlRepository.AddUser(userInfo);
                    user.Password = "";
                    return user;
                }
                else
                {
                    throw new Exception("Email Id Already Exists");
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<bool> ResetPassword(ResetPasswordModel resetPassword)
        {
            try
            {
                var user = await sqlRepository.GetUserByEmailId(resetPassword.emailId);
                if (user.Password.Trim() == resetPassword.oldPassword)
                {
                    user.Password = resetPassword.newPassword;
                    var userUpdated = await sqlRepository.UpdateUser(user);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public async Task<List<UserInfo>> GetAllUsers()
        {
            try {
                var users=await sqlRepository.GetAllUsers();
                foreach (var user in users)
                {
                    user.Password = "";
                }
                return users;
            }
            catch (Exception ex)
            {
                throw ex;

            }


        }
    }
}

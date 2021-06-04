using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApplication.Models;

namespace TweetApplication.Interface
{
   public interface IuserService
    {
        public Task<UserInfo> RegisterUser(UserInfo userInfo);
        public Task<UserInfo> LoginUser(LoginModel loginInfo);
        public Task<bool> ResetPassword(ResetPasswordModel resetPassword);
        public Task<List<UserInfo>> GetAllUsers();
    }
}

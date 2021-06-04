using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApplication.Models;

namespace TweetApplication.Interface
{
    public interface ISqlRepository
    {
        //db interaction only through this
        public Task<UserInfo> GetUserByEmailId(string emailId);
        public Task<UserInfo> GetUserByUserId(int userId);
        public Task<UserInfo> AddUser(UserInfo user);

        public Task<UserInfo> UpdateUser(UserInfo user);
        public Task<List<UserInfo>> GetAllUsers();

        public Task<List<TweetInfo>> GetAllTweets();
        public Task<List<TweetInfo>> GetAllTweetsByUser(string userId);
        public Task<TweetInfo> AddTweet(TweetInfo tweetInfo);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApplication.Models;

namespace TweetApplication.Interface
{
    public interface ItweetInterface
    {
        public Task<List<TweetInfo>> GetAllTweets();
        public Task<List<TweetInfo>> GetAllTweetsByUser(string userId);
        public Task<TweetInfo> AddTweet(TweetInfo tweetInfo);

    }
}

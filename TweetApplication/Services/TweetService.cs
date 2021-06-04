using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApplication.Interface;
using TweetApplication.Models;

namespace TweetApplication.Services
{
    public class TweetService : ItweetInterface
    {
        private readonly ISqlRepository sqlRepository;
        //dependency injection
        public TweetService(ISqlRepository _sqlRepository)
        {
            sqlRepository = _sqlRepository;
        }
        public async Task<TweetInfo> AddTweet(TweetInfo tweetInfo)
        {
            try
            {
                tweetInfo.CreatedOn = DateTime.UtcNow;
                tweetInfo.UpdatedOn = DateTime.UtcNow;
                var tweet = await sqlRepository.AddTweet(tweetInfo);

                return tweet;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<List<TweetInfo>> GetAllTweets()
        {
            try
            {
                return await  sqlRepository.GetAllTweets(); 
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<List<TweetInfo>> GetAllTweetsByUser(string userId)
        {
            try
            {
                return await sqlRepository.GetAllTweetsByUser(userId);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}

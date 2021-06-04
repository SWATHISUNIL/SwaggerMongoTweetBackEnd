using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApplication.Interface;
using TweetApplication.Models;

namespace TweetApplication.Repository
{
    public class SqlRepository : ISqlRepository
    {
        private readonly DbContext db;
        //private readonly DbSet<TweetInfo> tweetDb;
        //private readonly DbSet<UserInfo> userDb;
        private readonly IMongoCollection<UserInfo> userDb;
        private readonly IMongoCollection<TweetInfo> tweetDb;
        private readonly TweetAppConfig _settings;

        //public SqlRepository(TweetAppContext tweetAppContext)
        //{
        //    db = tweetAppContext;
        //    tweetDb = db.Set<TweetInfo>();
        //    userDb = db.Set<UserInfo>();

        //}
        public SqlRepository(IOptions<TweetAppConfig> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.TweetAppDbConnectionString);
            var database = client.GetDatabase(_settings.DataBaseName);
            userDb = database.GetCollection<UserInfo>(_settings.UserCollectionName);
            tweetDb = database.GetCollection<TweetInfo>(_settings.TweetsCollectionName);

        }
       
        public async Task<TweetInfo> AddTweet(TweetInfo tweetInfo)
        {
            //var tweet=tweetDb.Add(tweetInfo).Entity;
            await  tweetDb.InsertOneAsync(tweetInfo);
            //await db.SaveChangesAsync();

            return tweetInfo;
        }

        public async Task<UserInfo> AddUser(UserInfo userInfo)
        {
            //var user = await userDb.InsertOneAsync(userInfo);
             await userDb.InsertOneAsync(userInfo);
            //await db.SaveChangesAsync();
            return userInfo;
        }

        public async Task<List<TweetInfo>> GetAllTweets()
        {
            //return tweetDb.ToListAsync();
            return await tweetDb.Find(c => true).ToListAsync();
        }

        public async Task<List<TweetInfo>> GetAllTweetsByUser(string userId)
        {
            //return await tweetDb.Where(x => x.UserId == userId).ToListAsync();
           return  await tweetDb.Find<TweetInfo>(c => c.UserId.Equals(userId)).ToListAsync();
        }

        public async Task<UserInfo> GetUserByEmailId(string emailId)
        {
            //return  userDb.Where(x => x.Email == emailId).FirstOrDefault();
            return await userDb.Find<UserInfo>(c => c.Email == emailId).FirstOrDefaultAsync();
        }

        public async Task<UserInfo> GetUserByUserId(int userId)
        {
            //return userDb.Where(x => x.UserId == userId).FirstOrDefault();
            return await userDb.Find<UserInfo>(c => c.UserId.Equals(userId)).FirstOrDefaultAsync();
        }

        public async Task<UserInfo> UpdateUser(UserInfo userInfo)
        {
            //var user = userDb.Update(userInfo).Entity;
            //await _user.ReplaceOneAsync(c => c.UserId == user.UserId, user);
             await userDb.ReplaceOneAsync(c => c.UserId == userInfo.UserId,userInfo);
            //await db.SaveChangesAsync();
            return userInfo;
        }

        public async Task<List<UserInfo>> GetAllUsers()
        {
            //return await userDb.ToListAsync();
            return await userDb.Find(c => true).ToListAsync();
        }

    }
}

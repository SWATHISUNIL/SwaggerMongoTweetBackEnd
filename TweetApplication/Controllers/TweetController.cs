using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApplication.Interface;
using TweetApplication.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TweetApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly ItweetInterface itweetInterface;

        public TweetController(ItweetInterface _itweetInterface)
        {
            itweetInterface = _itweetInterface;
        }
        // GET: api/<TweetController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TweetController>/5
        [HttpGet]
        [Route("GetAllTweets")]
        public async Task<IActionResult> GetAllTweets()
        {
            try
            {

                var tweets = await itweetInterface.GetAllTweets();
                return new OkObjectResult(tweets);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        // GET api/<TweetController>/5
        [HttpGet]
        [Route("GetAllTweetByUserId/{UserId}")]
        public async Task<IActionResult> GetAllTweetByUserId(string UserId)
        {
            try
            {

                var tweets = await itweetInterface.GetAllTweetsByUser(UserId);
                return new OkObjectResult(tweets);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // POST api/<TweetController>
        [HttpPost]
        [Route("AddTweet")]
        public async Task<IActionResult> AddTweet([FromBody] TweetInfo tweetInfo)
        {
            try
            {
                var tweet = await itweetInterface.AddTweet(tweetInfo);
                return new OkObjectResult(tweet);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

     
    }
}

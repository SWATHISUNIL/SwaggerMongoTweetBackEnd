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
    public class UserController : ControllerBase
    {
        private readonly IuserService iuserService;

        public UserController(IuserService _iuserService)
        {
            iuserService = _iuserService;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {

                var users = await iuserService.GetAllUsers();
                return new OkObjectResult(users);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }


        // POST api/<UserController>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserInfo userInfo)
        {
            try 
            {
                if (userInfo != null)
                {
                    var user = await iuserService.RegisterUser(userInfo);
                    return new OkObjectResult(user);
                }
                else
                {
                    throw new Exception("User details are empty . Please enter the details.");
                }

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        // POST api/<UserController>
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel resetPassword)
        {
            try
            {
                var result = await iuserService.ResetPassword(resetPassword);
                if (result)
                {
                    return new OkObjectResult("User password has been changed successfully");
                }
                else
                    return new BadRequestObjectResult("Incorrect old password");

             }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        // POST api/<UserController>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            try
            {
                var result = await iuserService.LoginUser(login);
                if (result != null)
                {
                    return new OkObjectResult(result);
                }
                else
                    return new BadRequestObjectResult("Incorrect username/password");

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

    }
}

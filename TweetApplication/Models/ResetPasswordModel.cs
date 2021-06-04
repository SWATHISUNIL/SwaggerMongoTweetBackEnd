using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetApplication.Models
{
    public class ResetPasswordModel
    {
        public string emailId { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}

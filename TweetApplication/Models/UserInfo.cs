using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

#nullable disable

namespace TweetApplication.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            TweetInfos = new HashSet<TweetInfo>();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<TweetInfo> TweetInfos { get; set; }
    }
}

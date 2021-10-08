using System;
using MongoDB.Bson.Serialization.Attributes;

namespace _3K1SNRDB
{
    public class PostModel : ICommentable
    {
        [BsonId] public Guid id { get; set; }
        public Guid user_id { get; set; }
        public string text { get; set; }
        public DateTime post_time { get; set; }
    }
}
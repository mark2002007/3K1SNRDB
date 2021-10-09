using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace _3K1SNRDB
{
    public class CommentModel : ICommentable
    {
        [BsonId]
        public Guid id { get; set; }
        public Guid parent_id { get; set; }
        public Guid user_id { get; set; }
        public int depth { get; set; }
        public string text { get; set; }
        public DateTime comment_time { get; set; }
        public List<Guid> liked_by { get; set; }
    }
}
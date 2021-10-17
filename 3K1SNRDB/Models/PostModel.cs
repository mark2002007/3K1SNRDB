using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace _3K1SNRDB;

public class PostModel : ICommentable
{
    public Guid user_id { get; set; }
    public string text { get; set; }
    public DateTime post_time { get; set; }
    public List<Guid> liked_by { get; set; }
    [BsonId] public Guid id { get; set; }
}
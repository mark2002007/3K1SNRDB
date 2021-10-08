using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace _3K1SNRDB
{
    public class UserModel
    {
        [BsonId] public Guid id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public List<string> interests { get; set; }
        public List<Guid> friends_id { get; set; }
    }
}
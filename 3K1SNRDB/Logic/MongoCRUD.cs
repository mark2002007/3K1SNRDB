using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace _3K1SNRDB
{
    public class MongoCRUD
    {
        //public UserModel GetUserByLoginAndPassword(string login, string password) =>
        //    users_tab
        //        .Find(users_ftr.Eq("login", login)
        //              & users_ftr.Eq("password", password))
        //        .FirstOrDefault();
        //
        //public UserModel GetUserByLogin(string table, string login) =>
        //    users_tab
        //        .Find(users_ftr.Eq("login", login))
        //        .FirstOrDefault();
        //
        //public void DeleteRecord<T>(string table, Guid id)
        //{
        //    var collection = db.GetCollection<T>(table);
        //    var filter = new Builders<T>().Filter.Eq("_id", id);
        //}
        //public T LoadRecordById<T>(string table, Guid id) =>
        //    db.GetCollection<T>(table)
        //        .Find(Builders<T>.Filter.Eq("id", id))
        //        .First();
        //
        //public UserModel GetUserByLogin(string login)=>
        //    users_tab
        //        .Find(users_ftr.Eq("login", login))
        //        .FirstOrDefault();
        
        private IMongoDatabase db;
        private IMongoCollection<UserModel> users_tab;
        private FilterDefinitionBuilder<UserModel> users_ftr;
        private UpdateDefinitionBuilder<UserModel> users_upd;
        public MongoCRUD(string database)
        {
            db = new MongoClient().GetDatabase(database);
            users_tab = db.GetCollection<UserModel>("users");
            users_ftr = Builders<UserModel>.Filter;
            users_upd = Builders<UserModel>.Update;
        }

        public void InsertRecord<T>(string table, T record) => 
            db.GetCollection<T>(table)
                .InsertOne(record);

        public List<T> GetAllRecords<T>(string table) =>
            db.GetCollection<T>(table)
                .Find(new BsonDocument())
                .ToList();
        public void AddFriend(Guid userId, Guid friendId) =>
            users_tab.UpdateOne(users_ftr.Eq("id", userId),
                users_upd.Push("friends_id", friendId));
        public void RemoveFriend(Guid userId, Guid friendId) =>
            users_tab.UpdateOne(users_ftr.Eq("id", userId),
                users_upd.Pull("friends_id", friendId));
    }
}
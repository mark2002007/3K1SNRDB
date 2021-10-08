using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3K1SNRDB
{
    public class Controler
    {
        public static bool CheckPassword(string login, string password)
        {
            MongoCRUD db = new(Helper.dbName());
            var res = db.GetAllRecords<UserModel>("users").Where(u => u.login == login && u.password == password).FirstOrDefault();
            return res != null;
        }

        public static List<UserModel> GetAllUsers()
        {
            MongoCRUD db = new(Helper.dbName());
            var res = db.GetAllRecords<UserModel>("users");
            return res;
        }

        public static UserModel GetUserByLogin(string login)
        {
            MongoCRUD db = new(Helper.dbName());
            var res = db.GetAllRecords<UserModel>("users").Where(u => u.login == login).FirstOrDefault();
            return res;
        }

        public static void AddFriend(UserModel user, UserModel friend)
        {
            MongoCRUD db = new(Helper.dbName());
            if (db.GetAllRecords<UserModel>("users")
                .FirstOrDefault(u => u.id == user.id && u.friends_id.All(el => el != friend.id)) is not null)
                db.AddFriend(user.id, friend.id);
        }

        public static void RemoveFriend(UserModel user, UserModel friend)
        {
            MongoCRUD db = new(Helper.dbName());
            if (db.GetAllRecords<UserModel>("users")
                .FirstOrDefault(u => u.id == user.id && u.friends_id.Any(el => el == friend.id)) is not null)
                db.RemoveFriend(user.id, friend.id);
        }

        public static List<PostModel> GetAllPosts()
        {
            MongoCRUD db = new(Helper.dbName());
            var res = db.GetAllRecords<PostModel>("posts");
            return res;
        }

        public static UserModel GetUserByID(Guid id)
        {
            MongoCRUD db = new(Helper.dbName());
            var res = db.GetAllRecords<UserModel>("users").Where(u => u.id == id).FirstOrDefault();
            return res;
        }

        public static List<CommentModel> GetAllComments()
        {
            MongoCRUD db = new(Helper.dbName());
            var res = db.GetAllRecords<CommentModel>("comments");
            return res;
        }

        public static void AddComment(CommentModel comment)
        {
            MongoCRUD db = new(Helper.dbName());
            db.InsertRecord("comments", comment);
        }

        public static void AddPost(PostModel post)
        {
            MongoCRUD db = new(Helper.dbName());
            db.InsertRecord("posts", post);
        }
    }
}
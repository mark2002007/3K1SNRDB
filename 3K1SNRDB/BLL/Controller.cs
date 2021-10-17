using System;
using System.Collections.Generic;
using System.Linq;
using _3K1SNRDB.Logic;

namespace _3K1SNRDB;

public class Controller
{
    public static void AddComment(CommentModel comment)
    {
        MongoCRUD db = new(Helper.CnnVal());
        db.InsertRecord("comments", comment);
    }

    public static void AddFriend(UserModel user, UserModel friend)
    {
        MongoCRUD db = new(Helper.CnnVal());
        Neo4jCRUD ndb = new Neo4jCRUD();
        if (db.GetAllRecords<UserModel>("users")
                .FirstOrDefault(u => u.id == user.id && u.friends_id.All(el => el != friend.id)) is not null)
        {
            db.AddFriend(user.id, friend.id);
            ndb.AddFriend(user.id, friend.id);
        }
    }

    public static void AddLike(PostModel post, UserModel user)
    {
        MongoCRUD db = new(Helper.CnnVal());
        if (db.GetAllRecords<PostModel>("posts")
                .FirstOrDefault(p => p.id == post.id && p.liked_by.All(u_id => u_id != user.id)) is not null)
            db.AddLikeToPost(post.id, user.id);
    }

    public static void AddLike(CommentModel comment, UserModel user)
    {
        MongoCRUD db = new(Helper.CnnVal());
        if (db.GetAllRecords<CommentModel>("comments")
                .FirstOrDefault(c => c.id == comment.id && c.liked_by.All(u_id => u_id != user.id)) is not null)
            db.AddLikeToComment(comment.id, user.id);
    }

    public static void AddPost(PostModel post)
    {
        MongoCRUD db = new(Helper.CnnVal());
        db.InsertRecord("posts", post);
    }

    public static bool CheckPassword(string login, string password)
    {
        MongoCRUD db = new(Helper.CnnVal());
        var res = db.GetAllRecords<UserModel>("users").Where(u => u.login == login && u.password == password)
            .FirstOrDefault();
        return res != null;
    }

    public static List<CommentModel> GetAllComments()
    {
        MongoCRUD db = new(Helper.CnnVal());
        var res = db.GetAllRecords<CommentModel>("comments");
        return res;
    }

    public static List<PostModel> GetAllPosts()
    {
        MongoCRUD db = new(Helper.CnnVal());
        var res = db.GetAllRecords<PostModel>("posts");
        return res;
    }

    public static List<UserModel> GetAllUsers()
    {
        MongoCRUD db = new(Helper.CnnVal());
        var res = db.GetAllRecords<UserModel>("users");
        return res;
    }

    public static UserModel GetUserByID(Guid id)
    {
        MongoCRUD db = new(Helper.CnnVal());
        var res = db.GetAllRecords<UserModel>("users").Where(u => u.id == id).FirstOrDefault();
        return res;
    }

    public static UserModel GetUserByLogin(string login)
    {
        MongoCRUD db = new(Helper.CnnVal());
        var res = db.GetAllRecords<UserModel>("users").Where(u => u.login == login).FirstOrDefault();
        return res;
    }

    public static void RemoveFriend(UserModel user, UserModel friend)
    {
        MongoCRUD db = new(Helper.CnnVal());
        Neo4jCRUD ndb = new Neo4jCRUD();
        if (db.GetAllRecords<UserModel>("users")
                .FirstOrDefault(u => u.id == user.id && u.friends_id.Any(el => el == friend.id)) is not null)
        {
            db.RemoveFriend(user.id, friend.id);
            ndb.RemoveFriend(user.id, friend.id);
        }
            
    }

    public static void RemoveLike(PostModel post, UserModel user)
    {
        MongoCRUD db = new(Helper.CnnVal());
        if (db.GetAllRecords<PostModel>("posts")
                .FirstOrDefault(p => p.id == post.id && p.liked_by.Any(u_id => u_id == user.id)) is not null)
            db.RemoveLikeFromPost(post.id, user.id);
    }

    public static void RemoveLike(CommentModel comment, UserModel user)
    {
        MongoCRUD db = new(Helper.CnnVal());
        if (db.GetAllRecords<CommentModel>("comments")
                .FirstOrDefault(c => c.id == comment.id && c.liked_by.Any(u_id => u_id == user.id)) is not null)
            db.RemoveLikeFromComment(comment.id, user.id);
    }

    public static int GetDistanceToUser(Guid userFromId, Guid userToId)
    {
        Neo4jCRUD ndb = new Neo4jCRUD();
        return ndb.GetDistance(userFromId, userToId);
    }
}
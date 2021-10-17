using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace _3K1SNRDB;

public class MongoCRUD
{
    private readonly FilterDefinitionBuilder<CommentModel> comments_ftr;
    private readonly IMongoCollection<CommentModel> comments_tab;
    private readonly UpdateDefinitionBuilder<CommentModel> comments_upd;
    private readonly IMongoDatabase db;
    private readonly FilterDefinitionBuilder<PostModel> posts_ftr;
    private readonly IMongoCollection<PostModel> posts_tab;
    private readonly UpdateDefinitionBuilder<PostModel> posts_upd;
    private readonly FilterDefinitionBuilder<UserModel> users_ftr;
    private readonly IMongoCollection<UserModel> users_tab;
    private readonly UpdateDefinitionBuilder<UserModel> users_upd;

    public MongoCRUD(string database)
    {
        db = new MongoClient().GetDatabase(database);
        users_tab = db.GetCollection<UserModel>("users");
        users_ftr = Builders<UserModel>.Filter;
        users_upd = Builders<UserModel>.Update;
        posts_tab = db.GetCollection<PostModel>("posts");
        posts_ftr = Builders<PostModel>.Filter;
        posts_upd = Builders<PostModel>.Update;
        comments_tab = db.GetCollection<CommentModel>("comments");
        comments_ftr = Builders<CommentModel>.Filter;
        comments_upd = Builders<CommentModel>.Update;
    }

    public void AddFriend(Guid userId, Guid friendId) =>
        users_tab.UpdateOne(users_ftr.Eq("id", userId),
            users_upd.Push("friends_id", friendId));

    public void AddLikeToComment(Guid commentId, Guid userId) =>
        comments_tab.UpdateOne(comments_ftr.Eq("id", commentId),
            comments_upd.Push("liked_by", userId));

    public void AddLikeToPost(Guid postId, Guid userId) =>
        posts_tab.UpdateOne(posts_ftr.Eq("id", postId),
            posts_upd.Push("liked_by", userId));

    public List<T> GetAllRecords<T>(string table) =>
        db.GetCollection<T>(table)
            .Find(new BsonDocument())
            .ToList();

    public void InsertRecord<T>(string table, T record) =>
        db.GetCollection<T>(table)
            .InsertOne(record);

    public void RemoveFriend(Guid userId, Guid friendId) =>
        users_tab.UpdateOne(users_ftr.Eq("id", userId),
            users_upd.Pull("friends_id", friendId));

    public void RemoveLikeFromComment(Guid commentId, Guid userId) =>
        comments_tab.UpdateOne(comments_ftr.Eq("id", commentId),
            comments_upd.Pull("liked_by", userId));

    public void RemoveLikeFromPost(Guid postId, Guid userId) =>
        posts_tab.UpdateOne(posts_ftr.Eq("id", postId),
            posts_upd.Pull("liked_by", userId));
}
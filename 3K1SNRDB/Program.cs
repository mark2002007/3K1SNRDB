using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace _3K1SNRDB
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var usr_filter = Builders<UserModel>.Filter;
            //var coll = new MongoClient()
            //    .GetDatabase(Helper.dbName())
            //    .GetCollection<UserModel>("users");
            AddCommentsDummies();
            ApplicationConfiguration.Initialize();
            Application.Run(new signInForm());
        }

        private static void AddUsersDummies()
        {
            MongoCRUD db = new("3K1SNRDB_SocialNetwork_Part_1");
            db.InsertRecord("users", new UserModel
            {
                login = "gerik123",
                password = "123",
                first_name = "German",
                last_name = "Travolta",
                email = "germant@gmail.com",
                interests = new List<string> { "Basketball", "Judo", "Reading" },
                friends_id = new List<Guid>()
            });
            db.InsertRecord("users", new UserModel
            {
                login = "mark2002007",
                password = "1111",
                first_name = "Markiian",
                last_name = "Mandzak",
                email = "markmandzak2002@gmail.com",
                interests = new List<string> { "Diving", "Karate", "Football" },
                friends_id = new List<Guid>()
            });
            db.InsertRecord("users", new UserModel
            {
                login = "terryg333",
                password = "333",
                first_name = "Terry",
                last_name = "Golway",
                email = "terryg@gmail.com",
                interests = new List<string> { "Writing", "Philosophy" },
                friends_id = new List<Guid>()
            });
        }

        private static void AddPostsDummies()
        {
            MongoCRUD db = new("3K1SNRDB_SocialNetwork_Part_1");
            db.InsertRecord("posts", new PostModel
            {
                user_id = Controler.GetUserByLogin("mark2002007").id,
                text = @"Lorem ipsum dolor sit amet, consectetur adipiscing 
            elit. In a justo quis neque aliquet aliquam vitae a eros. Quisque eros nibh,
            interdum non risus ut, faucibus consequat lectus. Donec elementum nunc in massa
            blandit malesuada. Nulla sollicitudin elit sapien, euismod iaculis purus auctor vitae.
            Ut luctus eleifend ipsum, eleifend lacinia erat tincidunt posuere. Cras tincidunt leo 
            vel mattis bibendum. Suspendisse elit elit, viverra nec consectetur sit amet, molestie 
            a elit. Proin varius ac erat eget eleifend. Etiam elementum pulvinar tempor. Praesent 
            eget blandit elit, sed elementum eros. Nullam in pharetra ipsum, at viverra risus. 
            Etiam purus mi, pretium nec suscipit ornare, maximus ac ante. 
            Vestibulum gravida lectus velit, a placerat lectus condimentum sit amet.",
                post_time = DateTime.UtcNow
            });
            db.InsertRecord("posts", new PostModel
            {
                user_id = Controler.GetUserByLogin("gerik123").id,
                text = @"Morbi commodo ullamcorper nunc, quis pretium magna pretium vitae.
            Quisque pellentesque tincidunt nisi, placerat tristique elit fringilla id.
            Aliquam sollicitudin lectus at enim mattis dapibus eget a est. Ut non lorem id 
            erat dapibus pharetra vitae id magna. Praesent a arcu lacus. Praesent ac eros tincidunt
            enim pellentesque gravida. Ut et tristique est.",
                post_time = DateTime.UtcNow
            });
        }

        private static void AddFriends()
        {
            var client = new MongoClient();
            client.GetDatabase(Helper.dbName())
                .GetCollection<UserModel>("users")
                .UpdateOne(Builders<UserModel>.Filter.Eq("login", "mark2002007"),
                    Builders<UserModel>.Update.Set("friends_id",
                        new List<Guid> { new("6dad891a-0d07-4994-a888-531472709c80") }));
        }

        private static void AddCommentsDummies()
        {
            MongoCRUD db = new("3K1SNRDB_SocialNetwork_Part_1");
            //db.InsertRecord("comments", new CommentModel
            //{
            //    parent_id = Controler.GetAllPosts()[0].id,
            //    user_id = Controler.GetUserByLogin("mark2002007").id,
            //    depth = 0,
            //    text = "Comment to post with depth 0",
            //    comment_time = DateTime.UtcNow
            //});
            //db.InsertRecord("comments", new CommentModel
            //{
            //    parent_id = Controler.GetAllComments().Last().id,
            //    user_id = Controler.GetUserByLogin("gerik123").id,
            //    depth = 1,
            //    text = "Comment to comment with depth 1",
            //    comment_time = DateTime.UtcNow
            //});
            //db.InsertRecord("comments", new CommentModel
            //{
            //    parent_id = Controler.GetAllPosts().First().id,
            //    user_id = Controler.GetUserByLogin("terryg333").id,
            //    depth = 0,
            //    text = "Comment #2 to post with depth 0",
            //    comment_time = DateTime.UtcNow
            //});
            //db.InsertRecord("comments", new CommentModel
            //{
            //    parent_id = Controler.GetAllComments().First(el => el.depth == 1).id,
            //    user_id = Controler.GetUserByLogin("terryg333").id,
            //    depth = 2,
            //    text = "Comment to comment with depth 2",
            //    comment_time = DateTime.UtcNow
            //});

            //db.InsertRecord("comments", new CommentModel
            //{
            //    parent_id = Controler.GetAllPosts().Last().id,
            //    user_id = Controler.GetUserByLogin("mark2002007").id,
            //    depth = 0,
            //    text = "Post 2, Depth 0",
            //    comment_time = DateTime.UtcNow
            //});
            //db.InsertRecord("comments", new CommentModel
            //{
            //    parent_id = Controler.GetAllComments().Last().id,
            //    user_id = Controler.GetUserByLogin("gerik123").id,
            //    depth = 1,
            //    text = "Post 2, Depth 1",
            //    comment_time = DateTime.UtcNow
            //});
            //db.InsertRecord("comments", new CommentModel
            //{
            //    parent_id = Controler.GetAllComments().Last().id,
            //    user_id = Controler.GetUserByLogin("gerik123").id,
            //    depth = 2,
            //    text = "Post 2, Depth 2",
            //    comment_time = DateTime.UtcNow
            //});
        }
    }
}

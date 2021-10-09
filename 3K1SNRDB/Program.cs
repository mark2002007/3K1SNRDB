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
            //AddCommentsDummies();
            //AddUsersDummies();
            ApplicationConfiguration.Initialize();
            Application.Run(new signInForm());
        }

        private static void AddUsersDummies()
        {
            MongoCRUD db = new("3K1SNRDB_SocialNetwork_Part_1");
            //db.InsertRecord("users", new UserModel
            //{
            //    login = "gerik123",
            //    password = "123",
            //    first_name = "German",
            //    last_name = "Travolta",
            //    email = "germant@gmail.com",
            //    interests = new List<string> { "Basketball", "Judo", "Reading" },
            //    friends_id = new List<Guid>()
            //});
            //db.InsertRecord("users", new UserModel
            //{
            //    login = "mark2002007",
            //    password = "1111",
            //    first_name = "Markiian",
            //    last_name = "Mandzak",
            //    email = "markmandzak2002@gmail.com",
            //    interests = new List<string> { "Diving", "Karate", "Football" },
            //    friends_id = new List<Guid>()
            //});
            //db.InsertRecord("users", new UserModel
            //{
            //    login = "terryg333",
            //    password = "333",
            //    first_name = "Terry",
            //    last_name = "Golway",
            //    email = "terryg@gmail.com",
            //    interests = new List<string> { "Writing", "Philosophy" },
            //    friends_id = new List<Guid>()
            //});
            db.InsertRecord("users", new UserModel
            {
                login = "cilloferry",
                password = "cillianpassword",
                first_name = "Cillian",
                last_name = "Ferry",
                email = "cillianf@gmail.com",
                interests = new List<string> { "Baseball" },
                friends_id = new List<Guid>()
            });
            db.InsertRecord("users", new UserModel
            {
                login = "winstonNIC",
                password = "winstonPassword",
                first_name = "Winston",
                last_name = "Nicholls",
                email = "winstonn@gmail.com",
                interests = new List<string> { "Programming", "Gym", "Cooking" },
                friends_id = new List<Guid>()
            });
            db.InsertRecord("users", new UserModel
            {
                login = "BigBridgerBuilder",
                password = "laurelPassword",
                first_name = "Laurel",
                last_name = "Bridges",
                email = "laurelb@gmail.com",
                interests = new List<string> { "Building Bridges", "Architecture", "Art" },
                friends_id = new List<Guid>()
            });
            db.InsertRecord("users", new UserModel
            {
                login = "FireLord23",
                password = "munnebPassword",
                first_name = "Muneeb",
                last_name = "Burns",
                email = "munnebb@gmail.com",
                interests = new List<string> { "Fire Fighting", "Spikeball", "Knitting" },
                friends_id = new List<Guid>()
            });
            db.InsertRecord("users", new UserModel
            {
                login = "BestSeller1",
                password = "raulpassword",
                first_name = "Raul",
                last_name = "Sellers",
                email = "rauls@gmail.com",
                interests = new List<string> { "Marketing Managering", "Law", "Football" },
                friends_id = new List<Guid>()
            });
            db.InsertRecord("users", new UserModel
            {
                login = "SapphireMine3",
                password = "sapphirePassword",
                first_name = "Sapphire",
                last_name = "Holden",
                email = "sapphireh@gmail.com",
                interests = new List<string> { "Jewelry", "Music", "Gaming" },
                friends_id = new List<Guid>()
            });
            db.InsertRecord("users", new UserModel
            {
                login = "CocoLes4132",
                password = "cocoPassword",
                first_name = "Coco",
                last_name = "Coles",
                email = "cococ@gmail.com",
                interests = new List<string> { "Guitar", "Fighting" },
                friends_id = new List<Guid>()
            });
        }

        private static void AddPostsDummies()
        {
            MongoCRUD db = new("3K1SNRDB_SocialNetwork_Part_1");
            db.InsertRecord("posts", new PostModel
            {
                user_id = Controller.GetUserByLogin("mark2002007").id,
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
                post_time = DateTime.UtcNow,
                liked_by = new List<Guid>()
            });
            db.InsertRecord("posts", new PostModel
            {
                user_id = Controller.GetUserByLogin("gerik123").id,
                text = @"Morbi commodo ullamcorper nunc, quis pretium magna pretium vitae.
            Quisque pellentesque tincidunt nisi, placerat tristique elit fringilla id.
            Aliquam sollicitudin lectus at enim mattis dapibus eget a est. Ut non lorem id 
            erat dapibus pharetra vitae id magna. Praesent a arcu lacus. Praesent ac eros tincidunt
            enim pellentesque gravida. Ut et tristique est.",
                post_time = DateTime.UtcNow,
                liked_by = new List<Guid>()
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
            //    parent_id = Controller.GetAllPosts()[0].id,
            //    user_id = Controller.GetUserByLogin("mark2002007").id,
            //    depth = 0,
            //    text = "Comment to post with depth 0",
            //    comment_time = DateTime.UtcNow
            //});
            //db.InsertRecord("comments", new CommentModel
            //{
            //    parent_id = Controller.GetAllComments().Last().id,
            //    user_id = Controller.GetUserByLogin("gerik123").id,
            //    depth = 1,
            //    text = "Comment to comment with depth 1",
            //    comment_time = DateTime.UtcNow
            //});
            //db.InsertRecord("comments", new CommentModel
            //{
            //    parent_id = Controller.GetAllPosts().First().id,
            //    user_id = Controller.GetUserByLogin("terryg333").id,
            //    depth = 0,
            //    text = "Comment #2 to post with depth 0",
            //    comment_time = DateTime.UtcNow
            //});
            //db.InsertRecord("comments", new CommentModel
            //{
            //    parent_id = Controller.GetAllComments().First(el => el.depth == 1).id,
            //    user_id = Controller.GetUserByLogin("terryg333").id,
            //    depth = 2,
            //    text = "Comment to comment with depth 2",
            //    comment_time = DateTime.UtcNow
            //});

            //db.InsertRecord("comments", new CommentModel
            //{
            //    parent_id = Controller.GetAllPosts().Last().id,
            //    user_id = Controller.GetUserByLogin("mark2002007").id,
            //    depth = 0,
            //    text = "Post 2, Depth 0",
            //    comment_time = DateTime.UtcNow
            //});
            //db.InsertRecord("comments", new CommentModel
            //{
            //    parent_id = Controller.GetAllComments().Last().id,
            //    user_id = Controller.GetUserByLogin("gerik123").id,
            //    depth = 1,
            //    text = "Post 2, Depth 1",
            //    comment_time = DateTime.UtcNow
            //});
            //db.InsertRecord("comments", new CommentModel
            //{
            //    parent_id = Controller.GetAllComments().Last().id,
            //    user_id = Controller.GetUserByLogin("gerik123").id,
            //    depth = 2,
            //    text = "Post 2, Depth 2",
            //    comment_time = DateTime.UtcNow
            //});
        }
    }
}

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Comments;
using ByteSharp.Entities.Posts;
using ByteSharp.Managers;
using Comment = ByteSharp.Entities.Comments.Comment;
using Point = ByteSharp.Entities.Comments.Point;

namespace ByteSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = MainAsync(args);
            t.Wait();
        }

        private static WebManager _webManager { get; set; }

        static async Task MainAsync(string[] args)
        {
            var authManager = new AuthManager(new WebManager());
            Console.WriteLine("If you have an auth token, enter it below. Else leave blank: ");
            var authToken = Console.ReadLine();
            if (string.IsNullOrEmpty(authToken))
            {
                authToken = await MakeNewUser(authManager);
            }
            if (string.IsNullOrEmpty(authToken))
            {
                Console.WriteLine("Error getting auth token!");
            }

            _webManager = new WebManager(authToken);
            //await GetNames();
            //await GetUserInfo();
            //await MakePost();
            //await GetMessages();
            //await MakeComment();
            Console.ReadKey();
        }

        public static async Task MakeComment()
        {
            var postManager = new PostManager(_webManager);
            var files = await postManager.CreateNewFileSessionAsync();
            var result = await postManager.GetUsersPostsAsync();
            var post = result.Data.Posts.First();
            var commentManager = new CommentManager(_webManager);
            var results = await commentManager.MakeCommentAsync(post.Id, new NewComment()
            {
                Point = new Point()
                {
                    X = 15,
                    Y = 25
                },
                Body = "Test from C#!"
            });
        }

        public static async Task GetMessages()
        {
            var activityManager = new ActivityManager(_webManager);
            var results = await activityManager.GetMessagesAsync();
        }

        public static async Task MakeStar()
        {
            var postManager = new PostManager(_webManager);
            var starManager = new StarManager(_webManager);
            var files = await postManager.CreateNewFileSessionAsync();
            var result = await postManager.GetUsersPostsAsync();
            var post = result.Data.Posts.First();
            var star = await starManager.StarByteAsync(post.Id);
            var results = await starManager.GetStarsAsync();
            var deleteStar = await starManager.DeleteStarOnByteAsync(post.Id);
        }

        public static async Task MakePost()
        {
            var postManager = new PostManager(_webManager);
            var files = await postManager.CreateNewFileSessionAsync();
            var result = await postManager.GetUsersPostsAsync();
            var post = result.Data.Posts.First();
            //var newPost = new NewPost()
            //{
            //    caption = "Test Edit",
            //    name = "New Name",
            //    package = post.Package,
            //    thumbnailUrl = post.Thumbnails.Default.Url
            //};
            //var result2 = await postManager.CreateNewPostAsync(newPost);
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Image\Test.png");
            //var file = File.ReadAllBytes(path);
            //var result = await postManager.SendFileAsync(files.Data.Url, new MemoryStream(file));
            //Console.WriteLine(result.Data.Url);
        }

        public static async Task GetPosts()
        {
            var postManager = new PostManager(_webManager);
            var result = await postManager.GetLatestPostsAsync();
            var result2 = await postManager.GetPopularPostsAsync();
            var posts = result.Data.Posts;
            Console.WriteLine(posts.First().Name);
            var firstPostByName = await postManager.GetPostByNameAsync(posts.First().Name);
            Console.WriteLine(firstPostByName.Data.Post.Name);
        }

        public static async Task<string> MakeNewUser(AuthManager authManager)
        {
            Console.WriteLine("Enter your phone number: ");
            var number = Console.ReadLine();
            var codeResult = await authManager.RequestCodeAsync(number);
            Console.WriteLine("Enter the code you recieved: ");
            var code = Console.ReadLine();
            var authResult = await authManager.RegisterAsync(number, code);
            Console.WriteLine(authResult.Data.Token);
            return authResult.Data.Token;
        }

        public static async Task GetNames()
        {
            var nameManager = new NameManager(_webManager);
            var result = await nameManager.GetNamesAsync();
            Console.WriteLine($"First Generated Name: {result.Data.Names.First()}");

            var validResult = await nameManager.ValidateNameAsync(result.Data.Names.First());

            Console.WriteLine($"Is Valid: {validResult.Data.Ok} ");
        }

        public static async Task GetUserInfo()
        {
            var userManager = new UserManager(_webManager);
            var result = await userManager.GetAccountAsync();
            Console.WriteLine($"User Id: {result.Data.Id}");
            Console.WriteLine($"Description: {result.Data.Description}");

            var status = await userManager.GetStatusAsync();
            Console.WriteLine($"Latest Message: {status.Data.LatestMessageString}");
            Console.WriteLine($"Description: {status.Data.Description}");
            Console.WriteLine("Write new description: ");
            var des = Console.ReadLine();

            var newAccountResult = await userManager.UpdateAccountAsync(des);
            Console.WriteLine($"New Description: {newAccountResult.Data.Description}");

        }
    }
}

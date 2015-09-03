using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Auth;
using ByteSharp.Entities.Files;
using ByteSharp.Entities.Name;
using ByteSharp.Entities.Posts;
using ByteSharp.Interfaces;
using ByteSharp.Tools;
using Newtonsoft.Json;

namespace ByteSharp.Managers
{
    public class PostManager : IPostManager
    {
        private readonly IWebManager _webManager;
        public PostManager(IWebManager webManager)
        {
            _webManager = webManager;
        }


        public async Task<PostsResponse> GetPostByIdAsync(string id, string scheme = "full")
        {
            var result = await _webManager.GetData(new Uri(string.Format(Endpoints.PostById, id, scheme)));
            return JsonConvert.DeserializeObject<PostsResponse>(result.ResultJson);
        }

        public async Task<PostsResponse> GetPostByIdsAsync(string[] ids, string scheme = "full")
        {
            var groupIds = new GroupIds()
            {
                ids = ids
            };
            var result = await _webManager.PostData(new Uri(Endpoints.GroupPost), null, new StringContent(JsonConvert.SerializeObject(groupIds), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<PostsResponse>(result.ResultJson);
        }

        public async Task<PostsResponse> GetPostByNameAsync(string name, string scheme = "full")
        {
            var groupIds = new GroupName()
            {
                name = name
            };
            var result = await _webManager.PostData(new Uri(Endpoints.PostByName), null, new StringContent(JsonConvert.SerializeObject(groupIds), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<PostsResponse>(result.ResultJson);
        }

        public async Task<PostsResponse> GetPostByNamesAsync(string[] names, string scheme = "full")
        {
            var groupIds = new GroupNames()
            {
                names = names
            };
            var result = await _webManager.PostData(new Uri(Endpoints.PostByName), null, new StringContent(JsonConvert.SerializeObject(groupIds), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<PostsResponse>(result.ResultJson);
        }

        public async Task<PostsResponse> GetLatestPostsAsync(string cursor = "", string scheme = "full")
        {
            var result = await _webManager.GetData(new Uri(string.Format(Endpoints.PostLatest, scheme, cursor)));
            return JsonConvert.DeserializeObject<PostsResponse>(result.ResultJson);
        }

        public async Task<PostsResponse> GetPopularPostsAsync(string scheme = "full")
        {
            var result = await _webManager.GetData(new Uri(string.Format(Endpoints.PostPopular, scheme)));
            return JsonConvert.DeserializeObject<PostsResponse>(result.ResultJson);
        }

        public async Task<PostsResponse> GetUsersPostsAsync(string cursor = "", string scheme = "full")
        {
            var result = await _webManager.GetData(new Uri(string.Format(Endpoints.PostSelf, scheme, cursor)));
            return JsonConvert.DeserializeObject<PostsResponse>(result.ResultJson);
        }

        public async Task<PostsResponse> CreateNewPostAsync(NewPost post)
        {
            var result = await _webManager.PostData(new Uri(Endpoints.CreateByte), null, new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<PostsResponse>(result.ResultJson);
        }

        public async Task<PostsResponse> UpdatePostAsync(string id, NewPost post)
        {
            var result = await _webManager.PutData(new Uri(string.Format(Endpoints.UpdateDeletePost, id)), null, new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<PostsResponse>(result.ResultJson);
        }

        public async Task<DeleteByteResponse> DeleteByteResponseAsync(string id)
        {
            var result = await _webManager.DeleteData(new Uri(string.Format(Endpoints.UpdateDeletePost, id)), null);
            return JsonConvert.DeserializeObject<DeleteByteResponse>(result.ResultJson);
        }

        public async Task<FilesResponse> CreateNewFileSessionAsync()
        {
            var result = await _webManager.GetData(new Uri(Endpoints.FilesSession));
            return JsonConvert.DeserializeObject<FilesResponse>(result.ResultJson);
        }

        public async Task<FilesResponse> SendFileAsync(string uploadUrl, Stream stream)
        {
            StreamContent t;
            try
            {
                t = new StreamContent(stream);
                t.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                t.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                t.Headers.Add("Content-Description", "image-data-0");
                t.Headers.Add("Content-Transfer-Encoding", "binary");
                t.Headers.ContentLength = stream.Length;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create image", ex);
            }
            var form = new MultipartContent("mixed", "acebdf13572468") { t };
            var result = await _webManager.PostData(new Uri(uploadUrl), form, null);
            return JsonConvert.DeserializeObject<FilesResponse>(result.ResultJson);
        }

        private class GroupIds
        {
            public string[] ids;
        }

        private class GroupName
        {
            public string name;
        }

        private class GroupNames
        {
            public string[] names;
        }

    }
}

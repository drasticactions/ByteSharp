using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Files;
using ByteSharp.Entities.Posts;

namespace ByteSharp.Interfaces
{
    public interface IPostManager
    {
        Task<PostsResponse> GetPostByIdAsync(string id, string scheme = "full");

        Task<PostsResponse> GetPostByIdsAsync(string[] ids, string scheme = "full");

        Task<PostsResponse> GetPostByNameAsync(string name, string scheme = "full");

        Task<PostsResponse> GetPostByNamesAsync(string[] names, string scheme = "full");

        Task<PostsResponse> GetLatestPostsAsync(string cursor = "", string scheme = "full");

        Task<PostsResponse> GetPopularPostsAsync(string scheme = "full");

        Task<PostsResponse> GetUsersPostsAsync(string cursor = "", string scheme = "full");

        Task<PostsResponse> CreateNewPostAsync(NewPost post);

        Task<PostsResponse> UpdatePostAsync(string id, NewPost post);

        Task<DeleteByteResponse> DeleteByteResponseAsync(string id);

        Task<FilesResponse> CreateNewFileSessionAsync();

        Task<FilesResponse> SendFileAsync(string uploadUrl, Stream fileStream);
    }
}

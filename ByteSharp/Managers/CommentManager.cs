using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Comments;
using ByteSharp.Entities.Star;
using ByteSharp.Interfaces;
using ByteSharp.Tools;
using Newtonsoft.Json;

namespace ByteSharp.Managers
{
    public class CommentManager : ICommentManager
    {
        private readonly IWebManager _webManager;
        public CommentManager(IWebManager webManager)
        {
            _webManager = webManager;
        }


        public async Task<CommentResponse> MakeCommentAsync(string postId, NewComment comment)
        {
            var result = await _webManager.PostData(new Uri(string.Format(Endpoints.PostComment, postId)), null, new StringContent(JsonConvert.SerializeObject(comment)));
            return JsonConvert.DeserializeObject<CommentResponse>(result.ResultJson);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Posts;
using ByteSharp.Entities.Star;
using ByteSharp.Interfaces;
using ByteSharp.Tools;
using Newtonsoft.Json;

namespace ByteSharp.Managers
{
    public class StarManager : IStarManager
    {
        private readonly IWebManager _webManager;
        public StarManager(IWebManager webManager)
        {
            _webManager = webManager;
        }

        public async Task<StarResponse> StarByteAsync(string postId)
        {
            var result = await _webManager.PostData(new Uri(string.Format(Endpoints.AddRemoveStar, postId)), null, null);
            return JsonConvert.DeserializeObject<StarResponse>(result.ResultJson);
        }

        public async Task<StarResponse> DeleteStarOnByteAsync(string postId)
        {
            var result = await _webManager.DeleteData(new Uri(string.Format(Endpoints.AddRemoveStar, postId)), null);
            return JsonConvert.DeserializeObject<StarResponse>(result.ResultJson);
        }

        public async Task<StarResponse> GetStarsAsync(string cursor = "", string scheme = "full")
        {
            var result = await _webManager.GetData(new Uri(string.Format(Endpoints.GetFavs, scheme, cursor)));
            return JsonConvert.DeserializeObject<StarResponse>(result.ResultJson);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Flag;
using ByteSharp.Entities.Star;
using ByteSharp.Interfaces;
using ByteSharp.Tools;
using Newtonsoft.Json;

namespace ByteSharp.Managers
{
    public class FlagManager : IFlagsManager
    {
        private readonly IWebManager _webManager;
        public FlagManager(IWebManager webManager)
        {
            _webManager = webManager;
        }

        public async Task<FlagResponse> FlagByteAsync(string postId, string reason = "")
        {
            var result = await _webManager.PostData(new Uri(string.Format(Endpoints.AddRemoveFlag, postId)), null, null);
            return JsonConvert.DeserializeObject<FlagResponse>(result.ResultJson);
        }

        public async Task<FlagResponse> DeleteFlagOnByteAsync(string postId)
        {
            var result = await _webManager.DeleteData(new Uri(string.Format(Endpoints.AddRemoveFlag, postId)), null);
            return JsonConvert.DeserializeObject<FlagResponse>(result.ResultJson);
        }

        public async Task<FlagResponse> GetFlagsAsync(string cursor, string scheme = "full")
        {
            var result = await _webManager.GetData(new Uri(string.Format(Endpoints.GetFlags, scheme, cursor)));
            return JsonConvert.DeserializeObject<FlagResponse>(result.ResultJson);
        }
    }
}

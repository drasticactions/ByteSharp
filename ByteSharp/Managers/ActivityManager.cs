using System;
using System.Threading.Tasks;
using ByteSharp.Entities.Activity;
using ByteSharp.Entities.Star;
using ByteSharp.Interfaces;
using ByteSharp.Tools;
using Newtonsoft.Json;

namespace ByteSharp.Managers
{
    public class ActivityManager : IActivityManager
    {
        private readonly IWebManager _webManager;
        public ActivityManager(IWebManager webManager)
        {
            _webManager = webManager;
        }
        public async Task<ActivityResponse> GetMessagesAsync(string cursor = "")
        {
            var result = await _webManager.GetData(new Uri(string.Format(Endpoints.Messages, cursor)));
            return JsonConvert.DeserializeObject<ActivityResponse>(result.ResultJson);
        }
    }
}

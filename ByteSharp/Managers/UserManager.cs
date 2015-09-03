using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Auth;
using ByteSharp.Entities.User;
using ByteSharp.Interfaces;
using ByteSharp.Tools;
using Newtonsoft.Json;

namespace ByteSharp.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IWebManager _webManager;
        public UserManager(IWebManager webManager)
        {
            _webManager = webManager;
        }

        public async Task<UserResponse> GetStatusAsync()
        {
            var result = await _webManager.GetData(new Uri(Endpoints.Status));
            return JsonConvert.DeserializeObject<UserResponse>(result.ResultJson);
        }

        public async Task<UserResponse> GetAccountAsync()
        {
            var result = await _webManager.GetData(new Uri(Endpoints.Account));
            return JsonConvert.DeserializeObject<UserResponse>(result.ResultJson);
        }

        public async Task<UserResponse> UpdateAccountAsync(string description = "", string timezone = "America/New_York")
        {
            var account = new AccountEntity()
            {
                timeZone = timezone,
                description = description
            };
            var result = await _webManager.PostData(new Uri(Endpoints.Account), null, new StringContent(JsonConvert.SerializeObject(account), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<UserResponse>(result.ResultJson);
        }

        public async Task<UserResponse> DeactivateUserAsync()
        {
            var result = await _webManager.PostData(new Uri(Endpoints.Deactivate), null, null);
            return JsonConvert.DeserializeObject<UserResponse>(result.ResultJson);
        }

        public async Task<UserResponse> ReactivateUserAsync()
        {
            var result = await _webManager.PostData(new Uri(Endpoints.Reactivate), null, null);
            return JsonConvert.DeserializeObject<UserResponse>(result.ResultJson);
        }

        private class AccountEntity
        {
            public string timeZone { get; set; }

            public string description { get; set; }
        }
    }
}

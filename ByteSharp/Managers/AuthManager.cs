using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Auth;
using ByteSharp.Interfaces;
using ByteSharp.Tools;
using Newtonsoft.Json;
using PhoneNumbers;

namespace ByteSharp.Managers
{
    public class AuthManager : IAuthManager
    {
        private readonly IWebManager _webManager;
        public AuthManager(IWebManager webManager)
        {
            _webManager = webManager;
        }

        public async Task<bool> RequestCodeAsync(string phoneNumber)
        {
            var test = PhoneNumberUtil.GetInstance();
            var parsedNumber = test.Parse(phoneNumber, "US");
            var newNumber = test.Format(parsedNumber, PhoneNumberFormat.E164);
            var phone = new AuthEntity()
            {
                phone = newNumber
            };
            var result = await _webManager.PostData(new Uri(Endpoints.RequestCode), null, new StringContent(JsonConvert.SerializeObject(phone), Encoding.UTF8, "application/json"));
            var response = JsonConvert.DeserializeObject<AuthResponse>(result.ResultJson);
            return response.Success == 1;
        }

        public async Task<AuthResponse> RegisterAsync(string phoneNumber, string code, string timezone = "America/New_York")
        {
            var test = PhoneNumberUtil.GetInstance();
            var parsedNumber = test.Parse(phoneNumber, "US");
            var newNumber = test.Format(parsedNumber, PhoneNumberFormat.E164);
            var phone = new AuthEntity()
            {
                code = code,
                phone = newNumber,
                timezone = timezone
            };
            var result = await _webManager.PostData(new Uri(Endpoints.Auth), null, new StringContent(JsonConvert.SerializeObject(phone), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<AuthResponse>(result.ResultJson);
        }

        private class AuthEntity
        {
            public string timezone { get; set; }

            public string code { get; set; }
            public string phone { get; set; }
        }
    }
}

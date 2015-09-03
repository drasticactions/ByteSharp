using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Name;
using ByteSharp.Entities.User;
using ByteSharp.Interfaces;
using ByteSharp.Tools;
using Newtonsoft.Json;

namespace ByteSharp.Managers
{
    public class NameManager : INameManager
    {
        private readonly IWebManager _webManager;
        public NameManager(IWebManager webManager)
        {
            _webManager = webManager;
        }

        public async Task<NameResponse> GetNamesAsync()
        {
            var result = await _webManager.GetData(new Uri(Endpoints.Names));
            return JsonConvert.DeserializeObject<NameResponse>(result.ResultJson);
        }

        public async Task<NameResponse> ValidateNameAsync(string name)
        {
            var entity = new NameEntity()
            {
                name = name
            };
            var result = await _webManager.PostData(new Uri(Endpoints.ValidateName), null, new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<NameResponse>(result.ResultJson);
        }

        private class NameEntity
        {
            public string name { get; set; }
        }
    }
}

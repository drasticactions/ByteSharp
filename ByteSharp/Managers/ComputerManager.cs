using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.ComputerResult;
using ByteSharp.Entities.Computers;
using ByteSharp.Entities.ComputerSelectionResult;
using ByteSharp.Entities.Star;
using ByteSharp.Interfaces;
using ByteSharp.Tools;
using Newtonsoft.Json;

namespace ByteSharp.Managers
{
    public class ComputerManager : IComputerManager
    {
        private readonly IWebManager _webManager;
        public ComputerManager(IWebManager webManager)
        {
            _webManager = webManager;
        }


        public async Task<ComputersResponse> GetComputersAsync()
        {
            var result = await _webManager.GetData(new Uri(Endpoints.Computers));
            return JsonConvert.DeserializeObject<ComputersResponse>(result.ResultJson);
        }

        public async Task<ComputerSelectionResultResponse> GetSelectedComputerAsync(string subdomain)
        {
            var result = await _webManager.GetData(new Uri(Endpoints.ComputerBase + subdomain));
            return JsonConvert.DeserializeObject<ComputerSelectionResultResponse>(result.ResultJson);
        }

        public async Task<ComputerResultResponse> SendQueryToComputerAsync(string subdomain, string query)
        {
            var dataTest = new Data()
            {
                Query = query
            };
            var result = await _webManager.PostData(new Uri(Endpoints.ComputerBase + subdomain), null, new StringContent(JsonConvert.SerializeObject(dataTest), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<ComputerResultResponse>(result.ResultJson);
        }

        private class Data
        {

            [JsonProperty("query")]
            public string Query { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ByteSharp.Entities.Posts
{
    public class DeleteByteResponse
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("success")]
        public int Success { get; set; }
    }
}

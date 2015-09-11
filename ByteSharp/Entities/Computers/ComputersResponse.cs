using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ByteSharp.Entities.Computers
{
    public class ComputersResponse
    {
        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("Error")]
        public Error Error { get; set; }
    }
}

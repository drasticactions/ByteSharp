using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ByteSharp.Entities.ComputerResult
{
    public class ComputerResultResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}

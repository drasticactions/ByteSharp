using Newtonsoft.Json;

namespace ByteSharp.Entities.Flag
{
    public class FlagResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("Error")]
        public Error Error { get; set; }

        [JsonProperty("success")]
        public int Success { get; set; }
    }
}

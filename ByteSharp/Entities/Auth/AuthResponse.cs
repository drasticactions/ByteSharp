using Newtonsoft.Json;

namespace ByteSharp.Entities.Auth
{
    public class AuthResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("Error")]
        public Error Error { get; set; }

        [JsonProperty("success")]
        public int Success { get; set; }
    }
}

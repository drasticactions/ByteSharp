using Newtonsoft.Json;

namespace ByteSharp.Entities.Auth
{

    public class Data
    {

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

}

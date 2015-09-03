using Newtonsoft.Json;

namespace ByteSharp.Entities.Auth
{

    public class User
    {

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("creation")]
        public string Creation { get; set; }

        [JsonProperty("creationTime")]
        public int CreationTime { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

}

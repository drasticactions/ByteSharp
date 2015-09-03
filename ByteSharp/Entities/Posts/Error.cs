using Newtonsoft.Json;

namespace ByteSharp.Entities.Posts
{

    public class Error
    {

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }

}

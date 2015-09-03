using Newtonsoft.Json;

namespace ByteSharp.Entities.Files
{

    public class Error
    {

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }

}

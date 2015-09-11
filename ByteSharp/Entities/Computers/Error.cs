using Newtonsoft.Json;

namespace ByteSharp.Entities.Computers
{

    public class Error
    {

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }

}

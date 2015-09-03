using Newtonsoft.Json;

namespace ByteSharp.Entities.Name
{

    public class Data
    {

        [JsonProperty("names")]
        public string[] Names { get; set; }

        [JsonProperty("ok")]
        public bool Ok { get; set; }
    }

}

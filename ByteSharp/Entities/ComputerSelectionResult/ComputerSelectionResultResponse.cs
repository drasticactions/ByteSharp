using Newtonsoft.Json;

namespace ByteSharp.Entities.ComputerSelectionResult
{
    public class ComputerSelectionResultResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}

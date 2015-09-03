using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ByteSharp.Entities.Comments
{
    public class NewComment
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("sticker")]
        public string Sticker { get; set; }

        [JsonProperty("point")]
        public Point Point { get; set; }

    }
}

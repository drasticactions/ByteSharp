using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ByteSharp.Entities.Posts
{
    public class NewPost
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Package package { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string caption { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string thumbnailUrl { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool return_inflated_post { get; set; }
    }
}

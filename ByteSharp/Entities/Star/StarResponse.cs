﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ByteSharp.Entities.Star
{
    public class StarResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("Error")]
        public Error Error { get; set; }

        [JsonProperty("success")]
        public int Success { get; set; }
    }
}

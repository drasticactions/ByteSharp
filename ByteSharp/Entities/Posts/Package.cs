﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using Newtonsoft.Json;

namespace ByteSharp.Entities.Posts
{

    public class Package
    {

        [JsonProperty("objects", NullValueHandling = NullValueHandling.Ignore)]
        public Object[] Objects { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }

        [JsonProperty("background", NullValueHandling = NullValueHandling.Ignore)]
        public double[][] Background { get; set; }
    }

}

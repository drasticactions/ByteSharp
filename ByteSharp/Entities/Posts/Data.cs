﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using Newtonsoft.Json;

namespace ByteSharp.Entities.Posts
{

    public class Data
    {

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("posts")]
        public Post[] Posts { get; set; }

        [JsonProperty("post")]
        public Post Post { get; set; }

        [JsonProperty("more")]
        public bool More { get; set; }
    }

}

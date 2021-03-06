﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using Newtonsoft.Json;

namespace ByteSharp.Entities.Posts
{

    public class Object
    {

        [JsonProperty("src", NullValueHandling = NullValueHandling.Ignore)]
        public string Src { get; set; }

        [JsonProperty("frame", NullValueHandling = NullValueHandling.Ignore)]
        public double[] Frame { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("effects", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Effects { get; set; }

        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public double[] Color { get; set; }

        [JsonProperty("scaleMode", NullValueHandling = NullValueHandling.Ignore)]
        public string ScaleMode { get; set; }

        [JsonProperty("bpm", NullValueHandling = NullValueHandling.Ignore)]
        public int? Bpm { get; set; }

        [JsonProperty("length", NullValueHandling = NullValueHandling.Ignore)]
        public int? Length { get; set; }

        [JsonProperty("instructions", NullValueHandling = NullValueHandling.Ignore)]
        public object[][] Instructions { get; set; }

        [JsonProperty("style", NullValueHandling = NullValueHandling.Ignore)]
        public string Style { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("transform", NullValueHandling = NullValueHandling.Ignore)]
        public double[][] Transform { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("attributes", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Attributes { get; set; }

        [JsonProperty("alignment", NullValueHandling = NullValueHandling.Ignore)]
        public string Alignment { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public int? Size { get; set; }
    }

}

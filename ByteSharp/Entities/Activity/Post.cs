﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using Newtonsoft.Json;

namespace ByteSharp.Entities.Activity
{

    public class Post
    {

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("stickersCount")]
        public int StickersCount { get; set; }

        [JsonProperty("createdString")]
        public string CreatedString { get; set; }

        [JsonProperty("lookCount")]
        public int LookCount { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("thumbnailSrc")]
        public string ThumbnailSrc { get; set; }

        [JsonProperty("updatedString")]
        public string UpdatedString { get; set; }

        [JsonProperty("favCount")]
        public int FavCount { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("commentsCount")]
        public int CommentsCount { get; set; }

        [JsonProperty("thumbnails")]
        public Thumbnails Thumbnails { get; set; }
    }

}

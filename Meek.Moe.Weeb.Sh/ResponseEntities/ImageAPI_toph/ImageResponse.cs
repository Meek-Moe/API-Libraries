﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Meek.Moe.Weeb.Sh.ResponseEntities.ImageApi_toph
{
    public class ImageResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("baseType")]
        public string BaseType { get; set; }
        [JsonPropertyName("nsfw")]
        public bool Nsfw { get; set; }
        [JsonPropertyName("fileType")]
        public string FileType { get; set; }
        [JsonPropertyName("mimeType")]
        public string MimeType { get; set; }
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }
        [JsonPropertyName("account")]
        public string Account { get; set; }
    }
}
